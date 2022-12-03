using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using LMA.Data;
using LMA.Data.Contracts;
using LMA.Data.MSSQL;
using LMA.Services;
using LMA.Data.Contracts.Writers;
using LMA.Data.MSSQL.Writers;
using LMA.Data.Contracts.Readers;
using LMA.Data.MSSQL.Readers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using AutoMapper;
using LMA.Data.Models;
using LMA.Data.DbProvider;
using LMA.HostedServices;
using LMA.Services.Contracts;
using LMA.Data.Filters;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.UI.ViewModels.ViewModelValidators;
using LMAServer.Hubs;
using LMA.Data.DcProvider;
using LMA.Data.UI.ViewModels.Messages;
using LMA.Data.UI.ViewModels.ViewModels.Order;

namespace LMAServer
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			//================== AUTHENTICATION =====================
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateIssuerSigningKey = true,
					ValidateLifetime = true,
					ValidIssuer = "http://localhost:5000/",
					ValidAudience = "mysite.com",
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("akjsdfkjahskdjhfjkahskjhfkhmwveocnogweniotrnmxqweuhtcincmgqicg"))
				};
			});

			//================= HOSTED SERVICES =====================
			//services.AddHostedService<TimedHostedService>();
			//services.AddHostedService<RedisClient>();

			//================= DISTRIBUTED CACHE ===================
			//services.AddDistributedRedisCache(options =>
			//{
			//    options.Configuration = "localhost:6379";
			//    options.InstanceName = "SampleInstance";
			//});

			//services.AddTransient<IDcConnectionFactory>(f => new DcConnectionFactory(@"localhost:6379"));

			//================= SIGNALR =============================
			//services.AddSignalR();

			//================= MVC AND VALIDATION ==================
			services.AddMvc(options =>
				{
					options.Filters.Add(typeof(ModelFilter));
					options.Filters.Add(typeof(ResponseFilter));
				}).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

			//================= VALIDATORS ==========================
			services.AddSingleton<IValidator<CreateUserViewModel>, CreateUserViewModelValidator>();

			//================= MAPPERS =============================
			services.AddAutoMapper();

			//================= DATABASE CONNECTION =================
			services.AddTransient<IDbConnectionFactory>(f => new DbConnectionFactory(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gregor\Desktop\Database\MA_Database.mdf;Integrated Security=True;Connect Timeout=30"));
 
			//============== WRITERS ===================
			//Service for writing user data into database
			services.AddTransient<IWriter<UserModel>, UserWriter>();
			//Service for writing group data into userbase
			services.AddTransient<IWriter<CartItemModel>, CartWriter>();

			services.AddTransient<IWriter<AutoPartModel>, AutoPartWriter>();

			services.AddTransient<IWriter<OrderModel>, OrderWriter>();

			services.AddTransient<IWriter<AdminModel>, AdminWriter>();

            services.AddTransient<IWriter<EmployeeModel>, EmployeeWriter>();

            //============== READERS ===================
            services.AddTransient<IUserReader<UserModel>, UserReader>();

            services.AddTransient<IEmployeeReader<EmployeeModel>, EmployeeReader>();

            services.AddTransient<ICartReader<CartItemModel>, CartReader>();

			services.AddTransient<IAutoPartReader<AutoPartModel>, AutoPartReader>();

			services.AddTransient<IOrderReader<OrderModel>, OrderReader>();

			services.AddTransient<IAdminReader<AdminModel>, AdminReader>();



            //============== SERVICES ===================
            services.AddTransient(f => new LoginService(f.GetRequiredService<IUserReader<UserModel>>(),
														f.GetRequiredService<IMapper>()
														));

			services.AddTransient(f => new CartService(f.GetRequiredService<ICartReader<CartItemModel>>(),
														f.GetRequiredService<IWriter<CartItemModel>>(),
														f.GetRequiredService<IMapper>(),
														f.GetRequiredService<UserService>(),
                                                        f.GetRequiredService<IAutoPartReader<AutoPartModel>>()
                                                        ));

			services.AddTransient(f => new UserService(f.GetRequiredService<IUserReader<UserModel>>(),
														f.GetRequiredService<IWriter<UserModel>>(),
														f.GetRequiredService<IMapper>(),
														f.GetRequiredService<IAutoPartReader<AutoPartModel>>(),
														f.GetRequiredService<IWriter<OrderModel>>(),
                                                        f.GetRequiredService<IEmployeeReader<EmployeeModel>>(),
                                                        f.GetRequiredService<IWriter<EmployeeModel>>()
                                                       ));

			services.AddTransient(f => new AutoPartService(f.GetRequiredService<IWriter<AutoPartModel>>(),
														f.GetRequiredService<IAutoPartReader<AutoPartModel>>(),
                                                        f.GetRequiredService<IAdminReader<AdminModel>>(),
                                                        f.GetRequiredService<IMapper>(),
														f.GetRequiredService<UserService>()
														));

			services.AddTransient(f => new OrderService(f.GetRequiredService<IOrderReader<OrderModel>>(),
														f.GetRequiredService<IWriter<OrderModel>>(),
														f.GetRequiredService<IMapper>(),
														f.GetRequiredService<UserService>(),
                                                        f.GetRequiredService<IUserReader<UserModel>>(),
                                                        f.GetRequiredService<IAutoPartReader<AutoPartModel>>(),
                                                        f.GetRequiredService<CartService>(),
                                                        f.GetRequiredService<IAdminReader<AdminModel>>()
                                                        ));

            services.AddTransient(f => new EmployeeService(f.GetRequiredService<IEmployeeReader<EmployeeModel>>(),
                                                        f.GetRequiredService<IWriter<EmployeeModel>>(),
                                                        f.GetRequiredService<IAdminReader<AdminModel>>(),
                                                        f.GetRequiredService<IMapper>()
                                                        ));

            services.AddTransient(f => new AdminService(f.GetRequiredService<IAdminReader<AdminModel>>(),
														f.GetRequiredService<IWriter<AdminModel>>(),
														f.GetRequiredService<IMapper>()
														));


			//=============== SERVICE INTERFACES ==================
			services.AddTransient<ILoginService, LoginService>();
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<ICartService, CartService>();
			services.AddTransient<IAutoPartService, AutoPartService>();
			services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IAdminService, AdminService>();
		}

		//===============================================================================================================================================


		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseAuthentication();

			//app.UseSignalR(routes =>
			//{
			//    routes.MapHub<StatusSynch>("/status");
			//});

			app.UseMvc();

			app.UseDefaultFiles();
			app.UseStaticFiles();

			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("MA service didn't find anything");
			});
		}
	}
}

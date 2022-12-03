using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.DcProvider {
    public class BaseDcPersistance {
        protected readonly IDcConnectionFactory dcConnectionFactory;

        public BaseDcPersistance(IDcConnectionFactory dcConnectionFactory) {
            this.dcConnectionFactory = dcConnectionFactory;
        }
    }
}

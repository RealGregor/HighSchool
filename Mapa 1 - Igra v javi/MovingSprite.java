package graphicalUserInterface;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import java.awt.image.BufferedImage;
import java.util.ArrayList;

import javax.imageio.ImageIO;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.Timer;

public class MovingSprite extends JPanel implements KeyListener, ActionListener, MouseListener, MouseMotionListener{
	//change timer difficulty
	//add ships - your own and enemy
	//campaign mode - think about adding timer i guess or threads but timer is a thread so i guess ye?
	//2 - 3 levels in campaign mode? powerups? done
	//add powerups in survival mode? i think it would be a smart idea - scratch that, its brilliant
	/*i guess 1 level 3-4 minutes? ish lol no, 1 max
	 * update the help menu in the campaign mode - 4sure, controls are good i think although you can't press U there,
	 * .. more just thinking about it now
	 * improve collision detection for enemyShip2 and later enemyShip3
	 * */
	JFrame f;
	BufferedImage spaceship;
	BufferedImage spaceshipHit;
	BufferedImage missile;
	BufferedImage enemyMissile;
	BufferedImage enemyBullet;
	BufferedImage enemyBullet2;
	BufferedImage enemyLaser;
	BufferedImage enemyPlasmaBullet;
	BufferedImage enemyShip;
	BufferedImage enemyShip2;
	BufferedImage enemyShip2IsHit;
	BufferedImage enemyShip3;
	BufferedImage enemyShip3IsHit;
	BufferedImage enemy3Plasma;
	BufferedImage explosion;
	BufferedImage life;
	BufferedImage playButton;
	BufferedImage playButtonHover;
	BufferedImage optionsButton;
	BufferedImage optionsButtonHover;
	BufferedImage exitButton;
	BufferedImage exitButtonHover;
	BufferedImage resumeButton;
	BufferedImage resumeButtonHover;
	BufferedImage mainMenuButton;
	BufferedImage mainMenuButtonHover;
	BufferedImage helpButton;
	BufferedImage helpButtonHover;
	BufferedImage controlsButton;
	BufferedImage controlsButtonHover;
	BufferedImage backButton;
	BufferedImage backButtonHover;
	BufferedImage halfLife1;
	BufferedImage halfLife2;
	BufferedImage instructionsMovement;
	BufferedImage instructionsShooting;
	BufferedImage instructionsUpgrading;
	BufferedImage instructionsLives;
	BufferedImage spaceshipRight;
	BufferedImage missileRight;
	BufferedImage instructionsUp;
	BufferedImage instructionsDown;
	BufferedImage instructionsLeft;
	BufferedImage instructionsRight;
	BufferedImage instructionsSpace;
	BufferedImage instructionsUpgrade;
	BufferedImage instructionsPause;
	BufferedImage healthUpgrade;
	BufferedImage fireRateUpgrade;
	BufferedImage movementSpeedUpgrade;
	BufferedImage hullReinforcementUpgrade;
	BufferedImage enemyDamageDowngrade;
	BufferedImage upgrade;
	BufferedImage upgradeHover;
	BufferedImage notUpgraded;
	BufferedImage upgraded;
	BufferedImage maxUpgrade;
	BufferedImage resumeSmall;
	BufferedImage resumeSmallHover;
	BufferedImage scoreIndicator;
	BufferedImage retryButton;
	BufferedImage retryButtonHover;
	BufferedImage costIndicator;
	BufferedImage campaignButton;
	BufferedImage campaignButtonHover;
	BufferedImage survivalButton;
	BufferedImage survivalButtonHover;
	BufferedImage enemyBoss;
	BufferedImage enemyBossHit;
	BufferedImage enemyBoss2;
	BufferedImage enemyBoss2Hit;
	BufferedImage enemyBoss3;
	BufferedImage enemyBoss3Hit;
	BufferedImage boss3SecondaryDrone1;
	BufferedImage boss3SecondaryDrone2;
	BufferedImage droneBullet1;
	BufferedImage droneBullet2;
	BufferedImage speedPowerup;
	BufferedImage fireRatePowerup;
	BufferedImage healthPowerup;
	BufferedImage shieldPowerup;
	BufferedImage selectedPowerup;
	BufferedImage shield;
	BufferedImage space;
	
	ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
	
	boolean up = false;
	boolean down = false;
	boolean left = false;
	boolean right = false;
	boolean spacebar = false;
	boolean winMenu = false;
	boolean upgradeMenu = false;
	boolean gameOverMenu = false;
	boolean gameModeSelectionMenu = true;
	boolean mainMenu = false;
	boolean pauseMenu = false;
	boolean controlsMenu = false;
	boolean optionsMenu = false;
	boolean helpMenu = false;
	//boolean difficultyMenu = false;
	boolean hullReinforced = false;
	boolean reducedEnemyDamage = false;
	boolean campaignMode = false;
	boolean survivalMode = false;
	boolean level2 = false;// --> FALSE HERE
	boolean level3 = false;//--> TRUE HERE
	boolean boss = false;
	boolean wait = false;
	boolean primary = false;
	boolean secondary = false;
	
	byte enemy3Speed = 2;
	
	int spaceX = 300;
	int spaceY = 230;
	int time = 20;
	int timerPauseAmount = 0;
	int difficultyTimerInitialAmount = 20000;
	int levelTime = 30000;//have to balance it
	int bossAbilityTimeInitialAmount = 5100;
	int powerupTimeInitialAmount = 20000;
	int attackTime = 0;
	int dronesAttackTime = 0;
	int invulnerableTime = 0;
	int enemySpeed = 1;
	int mouseMovedX = 0;
	int mouseMovedY = 0;
	int bossHit = 0;//showing that boss was hit
	private int bossHealth = 0;
	int bossExplode = 0;//how many explosions you want to have
	int yourShipHit = 0;//indicator that shows that you've been hit(you ship turn red)
	
	int ex = -100;//new 
	double ey = -100;//new
	
	double bossY = -160;
	
	ArrayList<Integer> missilesX = new ArrayList<Integer>();
	ArrayList<Integer> missilesY = new ArrayList<Integer>();
	
	
	// ========== ENEMY SHIP TYPE 1 ========== //
	ArrayList<Integer> enemyShipX = new ArrayList<Integer>();
	ArrayList<Integer> enemyShipY = new ArrayList<Integer>();
	
	// ========== ENEMY SHIP TYPE 2 ========== //
	ArrayList<Integer> enemyShip2X = new ArrayList<Integer>();
	ArrayList<Integer> enemyShip2Y = new ArrayList<Integer>();
	ArrayList<Integer> enemyShip2Health = new ArrayList<Integer>();
	ArrayList<Integer> enemyShip2Hit = new ArrayList<Integer>();
	
	// ========== ENEMY SHIP TYPE 3 ========== //
	ArrayList<Integer> enemyShip3X = new ArrayList<Integer>();
	ArrayList<Integer> enemyShip3Y = new ArrayList<Integer>();
	ArrayList<Integer> enemyShip3Health = new ArrayList<Integer>();
	ArrayList<Integer> enemyShip3Hit = new ArrayList<Integer>();
	ArrayList<Integer> enemyShip3AttackTime = new ArrayList<Integer>();
	ArrayList<Integer> enemyPlasmaX = new ArrayList<Integer>();
	ArrayList<Integer> enemyPlasmaY = new ArrayList<Integer>();
	
	// ========== ENEMY TYPE ========== //
	ArrayList<Integer> enemyType = new ArrayList<Integer>();
	
	ArrayList<Integer> explosionsX = new ArrayList<Integer>();
	ArrayList<Integer> explosionsY = new ArrayList<Integer>();
	ArrayList<Integer> howManyRepaints = new ArrayList<Integer>();
	
	// ========== BOSS 1 ========== //
	//boss1 primary attack
	ArrayList<Integer> enemyMissilesX = new ArrayList<Integer>();
	ArrayList<Integer> enemyMissilesY = new ArrayList<Integer>();
	
	//boss1 secondary attack
	ArrayList<Double> enemyBulletsX = new ArrayList<Double>();
	ArrayList<Double> enemyBulletsY = new ArrayList<Double>();
	ArrayList<Double> deltaMoveX = new ArrayList<Double>();
	ArrayList<Double> deltaMoveY = new ArrayList<Double>();
	
	// ========== SHIP 2 ========== //
	//boss2 primary fire
	ArrayList<Integer> enemyLasersX = new ArrayList<Integer>();
	ArrayList<Integer> enemyLasersY = new ArrayList<Integer>();
	ArrayList<Integer> positions = new ArrayList<Integer>();//boss2 primary attack -> which lasers to show
	
	//boss2 secondary fire
	ArrayList<Double> enemyBullets2X = new ArrayList<Double>();
	ArrayList<Double> enemyBullets2Y = new ArrayList<Double>();
	ArrayList<Double> delta2X = new ArrayList<Double>();
	ArrayList<Double> delta2Y = new ArrayList<Double>();
	ArrayList<Double> accelaration = new ArrayList<Double>();
	ArrayList<Integer> enemyBullets2howManyRepaints = new ArrayList<Integer>();//only for bullets2 - explosions - make better graphics for this?
	ArrayList<Double> explosionsBullets2X = new ArrayList<Double>();
	ArrayList<Double> explosionsBullets2Y = new ArrayList<Double>();
	
	
	// ========== BOSS 3 ========== //
	//boss3 primary fire
	ArrayList<Double> enemyPlasmaBulletsX = new ArrayList<Double>();//new
	ArrayList<Double> enemyPlasmaBulletsY = new ArrayList<Double>();//new
	ArrayList<Double> deltaMovePlasmaBulletsX = new ArrayList<Double>();//new
	ArrayList<Double> deltaMovePlasmaBulletsY = new ArrayList<Double>();//new
	
	//boss3 secondary fire
	ArrayList<Integer> dronesX = new ArrayList<Integer>();//new
	ArrayList<Integer> dronesY = new ArrayList<Integer>();//new
	ArrayList<Double> droneBulletsX = new ArrayList<Double>();//new
	ArrayList<Double> droneBulletsY = new ArrayList<Double>();//new
	ArrayList<Double> droneBullets2X = new ArrayList<Double>();//new
	ArrayList<Double> droneBullets2Y = new ArrayList<Double>();//new 
	
	ArrayList<Integer> howManyRepaintsBoss = new ArrayList<Integer>();
	ArrayList<Integer> explosionsBossX = new ArrayList<Integer>();
	ArrayList<Integer> explosionsBossY = new ArrayList<Integer>();
	
	boolean moveDrone0 = false;
	boolean moveDrone1 = false;
	boolean moveDrone2 = false;
	boolean moveDrone3 = false;
	
	int countMissiles = 0;
	int countEnemySpaceships = 0;
	int countExplosions = 0;
	int countExplosionsBoss = 0; 
	int countEnemyMissiles = 0;
	int countEnemyBullets = 0;
	int countEnemySpaceships2 = 0; // counts enemies type2
	int countEnemyBullets2 = 0;//boss2 secondary attack
	int countEnemyBullets2Explosions = 0;//boss2
	int countBullets2Explosions = 0;//boss2 secondary attack, counts mines explosions
	int countEnemyLasers = 0;
	int countEnemySpaceships3 = 0;//new - count how many spaceships type 3 there are on the screen
	int countEnemyPlasma = 0;//new - count how many plasma "bullets/trails there are"
	int countEnemyPlasmaBullets = 0;// new - boss3 primary fire
	int countEnemyDroneBullets = 0;//new - boss3 secondary fire - drones on the left side
	int countEnemyDroneBullets2 = 0;//new - boss3 secondary fire - drones on the right side
	
	Timer t = new Timer(15, (ActionListener) this);
	Timer shipTimer = new Timer(time, (ActionListener) this);
	Timer menuTimer =  new Timer(15, (ActionListener) this);
	Timer difficultyTimer =  new Timer(20000, (ActionListener) this);
	Timer bossAbilityTimer = new Timer(3000, (ActionListener) this);
	Timer powerupTimer = new Timer(20000, (ActionListener) this);
	
	
	
	
	//Timer campaignShipTimer = new Timer(time, (ActionListener) this);
	
	int powerupX = 0;
	int powerupY = 500;
	int powerupTime = 0;
	byte shields = 0;
	
	long score = 0;
	int amount = 0;
	long compareTime = 0;
	int fireRate = 750;//rate of firing
	int halfLives = 10;
	int movementSpeed = 3;
	int helpMovementPixels = 0;
	int helpShootingPixels = 0;
	int healthUpgraded = 0;
	int movementSpeedUpgraded = 0;
	int fireRateUpgraded = 0;
	int healthUpgradeCost = 800;
	int fireRateUpgradeCost = 800;
	int movementSpeedUpgradeCost = 1000;
	int hullReinforcementCost = 4000;
	int reduceEnemyDamageCost = 4000;
	
	public MovingSprite() {
		f = new JFrame("Moving Sprite");
		f.setSize(736, 519);
		f.setLocation(300,  60);
		f.setVisible(true);
		f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		f.setLayout(null);
		f.setResizable(true);
		f.add(this);
		
		try {
			space = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\space.png"));
			spaceship = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\spaceshipUp.png"));
			spaceshipHit = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\spaceshipUpHit.png"));
			missile = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\missileUp.png"));
			spaceshipRight = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\spaceshipRight.png"));
			missileRight = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\missileRight.png"));
			enemyMissile = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\MissileDown.png"));
			enemyBullet = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemyBullet.png"));
			enemyBullet2 = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemyBullet2.png"));
			enemyLaser = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemyLaser.png"));
			enemyShip = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemy.png"));
			enemyShip2 = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemy2.png"));
			enemyShip2IsHit = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemy2Hit.png"));
			enemyShip3 = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemy3.png"));
			enemyShip3IsHit = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemy3Hit.png"));
			enemy3Plasma = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemy3Plasma.png"));
			explosion = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\explosion.png"));
			halfLife1 = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\halfLife.png"));
			playButton = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\playButton.png"));
			playButtonHover = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\playButtonHover.png"));
			optionsButton = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\optionsButton.png"));
			optionsButtonHover = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\optionsButtonHover.png"));
			exitButton = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\exitButton.png"));
			exitButtonHover = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\exitButtonHover.png"));
			resumeButton = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\resumeButton.png"));
			resumeButtonHover = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\resumeButtonHover.png"));
			halfLife2 = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\halfLife2.png"));
			mainMenuButton = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\mainMenu.png"));
			mainMenuButtonHover = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\mainMenuHover.png"));
			helpButton = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\helpButton.png"));
			helpButtonHover = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\helpButtonHover.png"));
			controlsButton = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\controlsButton.png"));
			controlsButtonHover = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\controlsButtonHover.png"));
			backButton = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\backButton.png"));
			backButtonHover = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\backButtonHover.png"));
			instructionsMovement = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\instructionsMovement.png"));
			instructionsShooting = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\instructionsShooting.png"));
			instructionsUpgrading = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\instructionsUpgrading.png"));
			instructionsUp = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\instructionsUp.png"));
			instructionsDown = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\instructionsDown.png"));
			instructionsLeft = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\instructionsLeft.png"));
			instructionsRight = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\instructionsRight.png"));
			instructionsSpace = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\instructionsSpace.png"));
			instructionsUpgrade = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\instructionsUpgrade.png"));
			instructionsPause = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\instructionsPause.png"));
			instructionsLives = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\instructionsLives.png"));
			healthUpgrade = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\healthUpgrade.png"));
			fireRateUpgrade = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\fireRateUpgrade.png"));
			movementSpeedUpgrade = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\movementSpeedUpgrade.png"));
			enemyDamageDowngrade = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemyDamageDowngrade.png"));
			hullReinforcementUpgrade = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\hullReinforcementUpgrade.png"));
			upgrade = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\upgrade.png"));
			upgradeHover = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\upgradeHover.png"));
			notUpgraded = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\notUpgraded.png"));
			upgraded = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\upgraded.png"));
			resumeSmall = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\resumeSmall.png"));
			resumeSmallHover = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\resumeSmallHover.png"));
			maxUpgrade = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\maxUpgrade.png"));
			scoreIndicator = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\scoreIndicator.png"));
			retryButton = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\retryButton.png"));
			retryButtonHover = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\retryButtonHover.png"));
			costIndicator = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\costIndicator.png"));
			campaignButton = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\campaign.png"));
			campaignButtonHover = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\campaignHover.png"));
			survivalButton = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\survival.png"));
			survivalButtonHover = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\survivalHover.png"));
			enemyBoss = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemyBoss.png"));
			enemyBossHit = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemyBossHit.png"));
			enemyBoss2 = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemyBoss2.png"));
			enemyBoss2Hit = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemyBoss2Hit.png"));
			enemyBoss3 = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemyBoss3.png"));
			enemyBoss3Hit = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\enemyBoss3Hit.png"));
			boss3SecondaryDrone1 = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\boss3SecondaryDrone1.png"));//new
			boss3SecondaryDrone2 = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\boss3SecondaryDrone2.png"));//new
			droneBullet1 = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\droneBullet1.png"));
			droneBullet2 = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\droneBullet2.png"));
			speedPowerup = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\speedPowerup.png"));
			fireRatePowerup = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\fireRatePowerup.png"));
			healthPowerup = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\healthPowerup.png"));
			shieldPowerup = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\shieldPowerup.png"));
			shield = ImageIO.read(classLoader.getResourceAsStream("Gongy Fongy\\shield.png"));
			
			//add enemyShip2 and enemyShip3 later	
			/*
			space = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\space.png"));
			spaceship = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\spaceshipUp.png"));
			spaceshipHit = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\spaceshipUpHit.png"));
			missile = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\missileUp.png"));
			spaceshipRight = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\spaceshipRight.png"));
			missileRight = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\missileRight.png"));
			enemyMissile = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\missileDown.png"));
			enemyBullet = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemyBullet.png"));//new
			enemyBullet2 = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemyBullet2.png"));//new
			enemyLaser = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemyLaser.png"));//new
			enemyPlasmaBullet = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemyPlasmaBullet.png"));//new
			enemyShip = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemy.png"));
			enemyShip2 = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemy2.png"));//HYA
			enemyShip2IsHit = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemy2Hit.png"));
			enemyShip3 = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemy3.png"));
			enemyShip3IsHit = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemy3Hit.png"));
			enemy3Plasma = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemy3Plasma.png"));//new-PLASMA
			explosion = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\explosion.png"));
			halfLife1 = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\halfLife.png"));
			playButton =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\playButton.png"));
			playButtonHover =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\playButtonHover.png"));
			optionsButton =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\optionsButton.png"));
			optionsButtonHover =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\optionsButtonHover.png"));
			exitButton =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\exitButton.png"));
			exitButtonHover =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\exitButtonHover.png"));
			resumeButton =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\resumeButton.png"));
			resumeButtonHover =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\resumeButtonHover.png"));
			halfLife2 = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\halfLife2.png"));
			mainMenuButton =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\mainMenu.png"));
			mainMenuButtonHover =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\mainMenuHover.png"));
			helpButton =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\helpButton.png"));
			helpButtonHover =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\helpButtonHover.png"));
			controlsButton =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\controlsButton.png"));
			controlsButtonHover =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\controlsButtonHover.png"));
			backButton =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\backButton.png"));
			backButtonHover =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\backButtonHover.png"));
			instructionsMovement =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\instructionsMovement.png"));
			instructionsShooting =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\instructionsShooting.png"));
			instructionsUpgrading =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\instructionsUpgrading.png"));
			instructionsUp =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\instructionsUp.png"));
			instructionsDown =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\instructionsDown.png"));
			instructionsLeft =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\instructionsLeft.png"));
			instructionsRight =  ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\instructionsRight.png"));
			instructionsSpace = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\instructionsSpace.png"));
			instructionsUpgrade = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\instructionsUpgrade.png"));
			instructionsPause = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\instructionsPause.png"));
			instructionsLives = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\instructionsLives.png"));
			healthUpgrade = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\healthUpgrade.png"));
			fireRateUpgrade = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\fireRateUpgrade.png"));
			movementSpeedUpgrade = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\movementSpeedUpgrade.png"));
			hullReinforcementUpgrade = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\hullReinforcementUpgrade.png"));
			enemyDamageDowngrade = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemyDamageDowngrade.png"));
			upgrade = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\upgrade.png"));
			upgradeHover = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\upgradeHover.png"));
			notUpgraded = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\notUpgraded.png"));
			upgraded = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\upgraded.png"));
			resumeSmall = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\resumeSmall.png"));
			resumeSmallHover = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\resumeSmallHover.png"));
			maxUpgrade = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\maxUpgrade.png"));
			scoreIndicator = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\scoreIndicator.png"));
			retryButton = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\retryButton.png"));
			retryButtonHover = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\retryButtonHover.png"));
			costIndicator = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\costIndicator.png"));
			campaignButton = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\campaign.png"));
			campaignButtonHover = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\campaignHover.png"));
			survivalButton = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\survival.png"));
			survivalButtonHover = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\survivalHover.png"));
			enemyBoss = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemyBoss.png"));
			enemyBossHit = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemyBossHit.png"));
			enemyBoss2 = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemyBoss2.png"));
			enemyBoss2Hit = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemyBoss2Hit.png"));
			enemyBoss3 = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemyBoss3.png"));
			enemyBoss3Hit = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\enemyBoss3Hit.png"));
			boss3SecondaryDrone1 = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\boss3SecondaryDrone1.png"));//new
			boss3SecondaryDrone2 = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\boss3SecondaryDrone2.png"));//new
			droneBullet1 = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\droneBullet1.png"));
			droneBullet2 = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\droneBullet2.png"));
			speedPowerup = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\speedPowerup.png"));
			fireRatePowerup = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\fireRatePowerup.png"));
			healthPowerup = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\healthPowerup.png"));
			shieldPowerup = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\shieldPowerup.png"));
			shield = ImageIO.read(new File("C:\\Users\\Gregor\\Desktop\\Gongy Fongy\\shield.png"));
			*/
		} catch (Exception e) {
			System.out.println("Some of the images could not be found");
			//e.printStackTrace();
		}
		dronesX.add(-30);
		dronesY.add(240);
		dronesX.add(-30);
		dronesY.add(385);
		dronesX.add(750);
		dronesY.add(240);
		dronesX.add(750);
		dronesY.add(385);
		this.setBounds(0, 0, 720, 480);//for now
		this.setBackground(Color.CYAN);
		f.addKeyListener(this);
		f.addMouseListener(this);
		f.addMouseMotionListener(this);
		menuTimer.start();
		//this will be if you press start buttong --  did ti-- actually just comemernetne haah komnetur sm
		//t.start();
		//shipTimer.start();
	}
	public void movePicture() {
		if(right) {
			if(spaceX <= 627) {spaceX += movementSpeed;}
		}
		if(left) {
			if(spaceX >= 3) {spaceX -= movementSpeed;}
		}
		if(up) {
			if(spaceY >= 3) {
				if(level3) {
					if(!boss || spaceY > bossY + 200) {
						spaceY -= movementSpeed;
					}
				}else if(level2) {
					if(!boss || spaceY > bossY + 230) {
						spaceY -= movementSpeed;
					}
				}else{
					if(!boss || spaceY > bossY + 160) {
						spaceY -= movementSpeed;
					}
				}
			}
		}
		if(down) {
			if(spaceY <= 387) {spaceY += movementSpeed;}
		}
	}
	public void moveMissiles() {
		for(int i = 0; i < countMissiles; i++) {
			int y = missilesY.get(i) - 3;
			missilesY.remove(i);
			if(y > -30) {
				missilesY.add(i, y);
			}else {
				missilesX.remove(i); 
				countMissiles--;
			}
		}
		
	}
	
	protected void createMissile() {
		if(compareTime <= 0 && spacebar) {
			missilesX.add(spaceX+25);
			missilesY.add(spaceY-15);
			countMissiles++;
			compareTime = fireRate;
		}
	}
	
	public void moveEnemySpaceship() {
		for(int i = 0; i < countEnemySpaceships; i++) {
			int y = enemyShipY.get(i) + 2;
			enemyShipY.remove(i);
			if(y < 485) {
				enemyShipY.add(i, y);
			}else {
				enemyShipX.remove(i);
				if(!reducedEnemyDamage && invulnerableTime <= 0) {
					if(shields > 0) {
						shields--;
					}else {
						halfLives-=2;
					}
					invulnerableTime = 900;
				}else if(invulnerableTime <= 0){
					if(shields > 0) {
						shields--;
					}else {
						halfLives--;
					}
					invulnerableTime = 900;
				}
				if(score != 0) {
					score -= 10;
				}
				countEnemySpaceships--;
			}
		}
		for(int i = 0; i < countEnemySpaceships2; i++) {
			int y = enemyShip2Y.get(i) + 2;
			enemyShip2Y.remove(i);
			if(y < 485) {
				enemyShip2Y.add(i, y);
			}else {
				enemyShip2X.remove(i);
				enemyShip2Health.remove(i);
				if(!reducedEnemyDamage && invulnerableTime <= 0) {
					if(shields > 0) {
						shields--;
					}else {
						halfLives-=2;
					}
					invulnerableTime = 900;
				}else if(invulnerableTime <= 0){
					if(shields > 0) {
						shields--;
					}else {
						halfLives--;
					}
					invulnerableTime = 900;
				}
				if(score != 0) {
					score -= 20;
				}
				countEnemySpaceships2--;
			}
		}
		for(int i = 0; i < countEnemySpaceships3; i++) {
			int y = enemyShip3Y.get(i) + enemy3Speed;
			enemyShip3Y.remove(i);
			if(y < 485) {
				enemyShip3Y.add(i, y);
			}else {
				enemyShip3X.remove(i);
				enemyShip3Health.remove(i);
				enemyShip3AttackTime.remove(i);
				if(!reducedEnemyDamage && invulnerableTime <= 0) {
					if(shields > 0) {
						shields--;
					}else {
						halfLives-=2;//or maybe -1 only? idk
					}
					invulnerableTime = 900;
				}else if(invulnerableTime <= 0){
					if(shields > 0) {
						shields--;
					}else {
						halfLives--;
					}
					invulnerableTime = 900;
				}
				if(score != 0) {
					score -= 30;
				}
				countEnemySpaceships3--;
			}
		}
	}
	
	protected void checkMissileCollision() {
		for(int i = 0; i < countEnemySpaceships; i++) {// type 1
			for(int j = 0; j < countMissiles; j++) {
				if(missilesX.get(j) <= enemyShipX.get(i)+35 && missilesX.get(j)+25 >= enemyShipX.get(i) && missilesY.get(j) <= enemyShipY.get(i)+20 && missilesY.get(j)+20 >= enemyShipY.get(i)) {
					explosionsX.add(enemyShipX.get(i));
					explosionsY.add(enemyShipY.get(i));
					enemyType.add(1);
					howManyRepaints.add(8);
					enemyShipY.remove(i);
					enemyShipX.remove(i);
					missilesX.remove(j); 
					missilesY.remove(j);
					countEnemySpaceships--;
					countMissiles--;
					countExplosions++;
					score += 20;
					break;
				}
			}
		}
		for(int i = 0; i < countEnemySpaceships2; i++) {// type 2
			for(int j = 0; j < countMissiles; j++) {
				if(missilesX.get(j) <= enemyShip2X.get(i)+35 && missilesX.get(j)+25 >= enemyShip2X.get(i) && missilesY.get(j) <= enemyShip2Y.get(i)+20 && missilesY.get(j)+20 >= enemyShip2Y.get(i)) {
					if(enemyShip2Health.get(i) == 0) {
						explosionsX.add(enemyShip2X.get(i));
						explosionsY.add(enemyShip2Y.get(i));
						enemyType.add(2);
						howManyRepaints.add(8);
						enemyShip2Y.remove(i);
						enemyShip2X.remove(i);
						enemyShip2Health.remove(i);
						enemyShip2Hit.remove(i);
						countEnemySpaceships2--;
						countExplosions++;
						score += 40;
					}else {
						enemyShip2Hit.remove(i);
						enemyShip2Hit.add(i, 8);
						enemyShip2Health.remove(i);
						enemyShip2Health.add(i, 0);
					}
					missilesX.remove(j); 
					missilesY.remove(j);
					countMissiles--;
					break;
				}
			}
		}
		for(int i = 0; i < countEnemySpaceships3; i++) {// type 3
			for(int j = 0; j < countMissiles; j++) {// do better collision check-with pixels
				if(missilesX.get(j) <= enemyShip3X.get(i)+50 && missilesX.get(j)+15 >= enemyShip3X.get(i) && missilesY.get(j) <= enemyShip3Y.get(i)+10) {
					if(enemyShip3Health.get(i) == 0) {
						explosionsX.add(enemyShip3X.get(i));
						explosionsY.add(enemyShip3Y.get(i));
						enemyType.add(3);
						howManyRepaints.add(8);
						enemyShip3Y.remove(i);
						enemyShip3X.remove(i);
						enemyShip3Health.remove(i);
						enemyShip3Hit.remove(i);
						countEnemySpaceships3--;
						countExplosions++;
						score += 60;
					}else {
						enemyShip3Hit.remove(i);
						enemyShip3Hit.add(i, 8);
						enemyShip3Health.remove(i);
						enemyShip3Health.add(i, 0);
					}
					missilesX.remove(j); 
					missilesY.remove(j);
					countMissiles--;
					break;
				}
			}
		}
	}
	
	
	public void checkEnemyMissilesCollision() {
		for(int i = 0; i < countEnemyMissiles; i++) {
				if((enemyMissilesX.get(i) >= spaceX+10 && enemyMissilesX.get(i) <= spaceX + 40 && enemyMissilesY.get(i) <= spaceY+70 && enemyMissilesY.get(i)+30 >= spaceY) || (enemyMissilesX.get(i) >= spaceX-10 && enemyMissilesX.get(i) < spaceX + 10 && enemyMissilesY.get(i) <= spaceY+70 && enemyMissilesY.get(i)-20 >= spaceY) || (enemyMissilesX.get(i) > spaceX+40 && enemyMissilesX.get(i) <= spaceX + 60 && enemyMissilesY.get(i) <= spaceY+70 && enemyMissilesY.get(i)-20 >= spaceY)) {
					yourShipHit = 10;
					enemyMissilesX.remove(i); enemyMissilesY.remove(i);
					countEnemyMissiles--;
					if(invulnerableTime <= 0) {
						if(shields > 0) {
							shields--;
						}else {
							halfLives--;
						}
						invulnerableTime = 900;
					}
					break;
				}
		}
	}
	
	
	public void checkEnemySpaceshipCollision() {
		for(int i = 0; i < countEnemySpaceships; i++) {//for ships type 1
			int y = enemyShipY.get(i);
			int x = enemyShipX.get(i);
			enemyShipY.remove(i);
			enemyShipX.remove(i);
			if((y+40 >= spaceY && y<=spaceY+70 && x+4 >= spaceX && x <= spaceX+45) || (y-10 >= spaceY && y<=spaceY+80 && x+25 >= spaceX && x <= spaceX+65)) {
				explosionsX.add(x);
				explosionsY.add(y);
				enemyType.add(1);
				howManyRepaints.add(8);
				if(!hullReinforced && invulnerableTime <= 0) {
					yourShipHit = 10;
					invulnerableTime = 900;
					if(shields > 0) {
						shields--;
					}else {
						halfLives--;
					}
				}
				score += 10;
				countEnemySpaceships--;
				countExplosions++;
			}else {
				enemyShipX.add(i, x);
				enemyShipY.add(i, y);
			}
		}
		for(int i = 0; i < countEnemySpaceships2; i++) {//for ships type 2
			int y = enemyShip2Y.get(i);
			int x = enemyShip2X.get(i);
			enemyShip2Y.remove(i);
			enemyShip2X.remove(i);
			if((y+40 >= spaceY && y<=spaceY+70 && x+4 >= spaceX && x <= spaceX+45) || (y-10 >= spaceY && y<=spaceY+80 && x+25 >= spaceX && x <= spaceX+65)) {
				explosionsX.add(x);
				explosionsY.add(y);
				enemyType.add(2);
				howManyRepaints.add(8);
				enemyShip2Health.remove(i);
				if(hullReinforced && invulnerableTime <= 0) {
					yourShipHit = 10;
					if(shields > 0) {
						shields--;
					}else {
						halfLives--;
					}
					invulnerableTime = 900;
				}else if(invulnerableTime <= 0){
					yourShipHit = 10;
					if(shields > 0) {
						shields--;
					}else {
						halfLives-=2;
					}
					invulnerableTime = 900;
				}
				score += 20;
				countEnemySpaceships2--;
				countExplosions++;
			}else {
				enemyShip2X.add(i, x);
				enemyShip2Y.add(i, y);
			}
		}
		for(int i = 0; i < countEnemySpaceships3; i++) {//for ships type 3
			int y = enemyShip3Y.get(i);
			int x = enemyShip3X.get(i);
			enemyShip3Y.remove(i);
			enemyShip3X.remove(i);
			if((x >= spaceX-10 &&  x <= spaceX+30 && y >= spaceY-35 && y <= spaceY+70) || (x >= spaceX-36 &&  x < spaceX+10 && y >= spaceY+10 && y <= spaceY+70) || (x > spaceX+30 &&  x <= spaceX+60 && y >= spaceY+10 && y <= spaceY+70)) {
				explosionsX.add(x);
				explosionsY.add(y);
				enemyType.add(3);
				howManyRepaints.add(8);
				enemyShip3Health.remove(i);
				if(hullReinforced && invulnerableTime <= 0) {
					yourShipHit = 10;
					invulnerableTime = 900;//think about not doing this?nahkepe it
				}else if(invulnerableTime <= 0){
					yourShipHit = 10;
					if(shields > 0) {
						shields--;
					}else {
						halfLives--;
					}
					invulnerableTime = 900;
				}
				score += 30;
				countEnemySpaceships3--;
				countExplosions++;
			}else {
				enemyShip3X.add(i, x);
				enemyShip3Y.add(i, y);
			}
		}
	}
	public void checkEnemyBulletsCollision() {
		for(int i = 0; i < countEnemyBullets; i++) {//change x and y here
			if((enemyBulletsX.get(i) >= spaceX+30 && enemyBulletsX.get(i) <= spaceX + 40 && enemyBulletsY.get(i) <= spaceY+70 && enemyBulletsY.get(i)+10 >= spaceY) || (enemyBulletsX.get(i) >= spaceX && enemyBulletsX.get(i) < spaceX + 40 && enemyBulletsY.get(i) <= spaceY+70 && enemyBulletsY.get(i)-20 >= spaceY) || (enemyBulletsX.get(i) > spaceX+40 && enemyBulletsX.get(i) <= spaceX + 60 && enemyBulletsY.get(i) <= spaceY+70 && enemyBulletsY.get(i)-20 >= spaceY)) {
				//make it so you are invulnerable for 1-2 seconds
				yourShipHit = 10;//makes your ship red(you were hurt), think about not doing this if you don't lose life
				enemyBulletsX.remove(i); 
				enemyBulletsY.remove(i);
				deltaMoveX.remove(i);
				deltaMoveY.remove(i);
				countEnemyBullets--;
				if(invulnerableTime <= 0) {
					if(shields > 0) {
						shields--;
					}else {
						halfLives--;
					}//add invulnerableTime here - did
					invulnerableTime = 900;
				}
				break;
			}
		}
	}
	public void checkEnemyLasersCollision() {
		for(int i = countEnemyLasers-1; i >= 0; i--) {//think about pixels a little more
			if((enemyLasersX.get(i) >= spaceX+30 && enemyLasersX.get(i) < spaceX + 50 && enemyLasersY.get(i) >= spaceY-40+45) || (enemyLasersX.get(i) >= spaceX+5 && enemyLasersX.get(i) < spaceX + 30 && enemyLasersY.get(i) >= spaceY+10+45) || (enemyLasersX.get(i) >= spaceX+50 && enemyLasersX.get(i) < spaceX + 75 && enemyLasersY.get(i) >= spaceY+10+45)) {
				yourShipHit = 10;//makes your ship red(you were hurt), think about not doing this if you don't lose life
				int y = enemyLasersY.get(i);
				int x1 = 0;
				int x2 = 0;
				if(enemyLasersX.get(i) >= spaceX+30 && enemyLasersX.get(i) < spaceX + 50) {
					x1 = spaceX+30;
					x2 = spaceX+50;
				}else if(enemyLasersX.get(i) >= spaceX+5 && enemyLasersX.get(i) < spaceX + 30) {
					x1 = spaceX+5;
					x2 = spaceX+30;
				}else {
					x1 = spaceX+50;
					x2 =spaceX+75;
				}
				for(int j = i; j >= 0; j--) {
					if(enemyLasersX.get(j) >= x1 && enemyLasersX.get(j) <= x2 && enemyLasersY.get(j) >= y) {
						enemyLasersX.remove(j); 
						enemyLasersY.remove(j);
						countEnemyLasers--;
						i--;
					}
				}
				if(invulnerableTime <= 0) {
					if(shields > 0) {
						shields--;
					}else {
						halfLives--;
					}//add invulnerableTime here - did
					invulnerableTime = 900;
				}
				//break;
			}
		}
	}
	public void checkEnemy3PlasmaCollision() {
		for(int i = 0; i < countEnemyPlasma; i++) {
			if((enemyPlasmaX.get(i) >= spaceX+5 && enemyPlasmaX.get(i) < spaceX+30 && enemyPlasmaY.get(i) <= spaceY+70 && enemyPlasmaY.get(i) >= spaceY+40) || (enemyPlasmaX.get(i) > spaceX+30 && enemyPlasmaX.get(i) < spaceX+50 && enemyPlasmaY.get(i) <= spaceY+70 && enemyPlasmaY.get(i) >= spaceY-20) || (enemyPlasmaX.get(i) >= spaceX+50 && enemyPlasmaX.get(i) <= spaceX+75 && enemyPlasmaY.get(i) <= spaceY+70 && enemyPlasmaY.get(i) >= spaceY+40)) {
				yourShipHit = 10;//indikator, da je bila igralna figura zadeta
				enemyPlasmaX.remove(i); //odstranimo X koordinato izstrelka
				enemyPlasmaY.remove(i);	//odstranimo Y koordinato izstrelka
				countEnemyPlasma--; //izstrelek odstranimo
				if(invulnerableTime <= 0) {//èe figura trenutno ni ranljiva
					if(shields > 0) {
						shields--;
					}else {
						halfLives--;
					}
					invulnerableTime = 900;//igralna figura je neranljiva 0.9s
				}
				break;
			}
		}
	}
	public void checkEnemyBullets2Collision() {
		for(int i = 0; i < countEnemyBullets2; i++) {
			double y = enemyBullets2Y.get(i);
			double x = enemyBullets2X.get(i);
			enemyBullets2Y.remove(i);
			enemyBullets2X.remove(i);
			if((x >= spaceX && x <= spaceX+50 && y <= spaceY+70 && y >= spaceY-20) || (x > spaceX-20 && x < spaceX && y <= spaceY+70 && y >= spaceY+30) || (x > spaceX+50 && x < spaceX+70 && y <= spaceY+70 && y >= spaceY+30)) {
				explosionsBullets2X.add(x*1.0);
				explosionsBullets2Y.add(y*1.0);
				enemyBullets2howManyRepaints.add(8);
				yourShipHit = 10;
				if(invulnerableTime <= 0) {
					invulnerableTime = 900;
					if(shields > 0) {
						shields--;
					}else {
						halfLives--;
					}
				}
				delta2X.remove(i);
				delta2Y.remove(i);
				accelaration.remove(i);
				countEnemyBullets2--;
				countBullets2Explosions++;
			}else {
				enemyBullets2X.add(i, x);
				enemyBullets2Y.add(i, y);
			}
		}
	}
	public void checkEnemyBullets2MissileCollision() {
		for(int i = 0; i < countEnemyBullets2; i++) {//make it prettier?
			for(int j = 0; j < countMissiles; j++) {
				if(missilesX.get(j) <= enemyBullets2X.get(i)+20 && missilesX.get(j)+20 >= enemyBullets2X.get(i) && missilesY.get(j) <= enemyBullets2Y.get(i)+20 && missilesY.get(j)+20 >= enemyBullets2Y.get(i)) {
					explosionsBullets2X.add(enemyBullets2X.get(i));
					explosionsBullets2Y.add(enemyBullets2Y.get(i));
					enemyBullets2howManyRepaints.add(8);
					enemyBullets2X.remove(i);
					enemyBullets2Y.remove(i);
					delta2X.remove(i);
					delta2Y.remove(i);
					accelaration.remove(i);
					missilesX.remove(j); 
					missilesY.remove(j);
					countEnemyBullets2--;
					countMissiles--;
					countBullets2Explosions++;
					break;
				}
			}
		}
	}
	public void checkEnemyPlasmaBulletsCollision() {
		for(int i = 0; i < countEnemyPlasmaBullets; i++) {
			double y = enemyPlasmaBulletsY.get(i);
			double x = enemyPlasmaBulletsX.get(i);
			enemyPlasmaBulletsY.remove(i);
			enemyPlasmaBulletsX.remove(i);
			if((x >= spaceX+20 && x <= spaceX+50 && y <= spaceY+70 && y >= spaceY) || (x > spaceX-20 && x < spaceX+20 && y <= spaceY+70 && y >= spaceY+30) || (x > spaceX+50 && x < spaceX+80 && y <= spaceY+70 && y >= spaceY+30)) {
				yourShipHit = 10;
				if(invulnerableTime <= 0) {
					invulnerableTime = 900;
					if(shields > 0) {
						shields--;
					}else {
						halfLives--;
					}
				}
				deltaMovePlasmaBulletsX.remove(i);
				deltaMovePlasmaBulletsY.remove(i);
				countEnemyPlasmaBullets--;
			}else {
				enemyPlasmaBulletsX.add(i, x);
				enemyPlasmaBulletsY.add(i, y);
			}
		}
	}
	public void checkDroneBulletsCollision() {
		for(int i = 0; i < countEnemyDroneBullets; i++) {
			double y = droneBulletsY.get(i);
			double x = droneBulletsX.get(i);
			droneBulletsY.remove(i);
			droneBulletsX.remove(i);
			if((x >= spaceX-38 && x <= spaceX+75 && y <= spaceY+63 && y >= spaceY+55) || (x >= spaceX-21 && x < spaceX+57 && y <= spaceY+55 && y >= spaceY+25) || (x >= spaceX-7 && x <= spaceX+47 && y < spaceY+25 && y >= spaceY)) {
				yourShipHit = 10;
				if(invulnerableTime <= 0) {
					invulnerableTime = 900;
					halfLives--;
				}
				countEnemyDroneBullets--;
				//break+
			}else {
				droneBulletsX.add(i, x);
				droneBulletsY.add(i, y);
			}
		}
		for(int i = 0; i < countEnemyDroneBullets2; i++) {
			double y = droneBullets2Y.get(i);
			double x = droneBullets2X.get(i);
			droneBullets2Y.remove(i);
			droneBullets2X.remove(i);
			if((x >= spaceX-38 && x <= spaceX+75 && y <= spaceY+63 && y >= spaceY+55) || (x >= spaceX-21 && x < spaceX+57 && y <= spaceY+55 && y >= spaceY+25) || (x >= spaceX-7 && x <= spaceX+47 && y < spaceY+25 && y >= spaceY)) {
				yourShipHit = 10;
				if(invulnerableTime <= 0) {
					invulnerableTime = 900;
					if(shields > 0) {
						shields--;
					}else {
						halfLives--;
					}
				}
				countEnemyDroneBullets2--;
				//break
			}else {
				droneBullets2X.add(i, x);
				droneBullets2Y.add(i, y);
			}
		}
	}
	
	
	
	public void checkPowerupCollision() {
		int y = powerupY;
		int x = powerupX;
		if((x >= spaceX+20 && x <= spaceX+50 && y <= spaceY+70 && y >= spaceY) || (x > spaceX-20 && x < spaceX+20 && y <= spaceY+70 && y >= spaceY+30) || (x > spaceX+50 && x < spaceX+80 && y <= spaceY+70 && y >= spaceY+30)) {
			powerupY = 500;
			powerupTime = 10000;
			if(selectedPowerup == speedPowerup) {
				movementSpeed++;
			}else if(selectedPowerup == fireRatePowerup) {
				fireRate = 300;
			}else if(selectedPowerup == healthPowerup) {
				if(halfLives < 8) {
					halfLives += 2;
				}else{
					halfLives = 10;
				}
			}else {
				if(shields < 5) {
					shields++;
				}
			}
		}
	}
	

	public void moveBoss() {
		if(bossY < 0 && bossExplode == 0) {
			bossY += 0.5;
			if(level3) {
				if(spaceY <= bossY+3+200) {
					spaceY += 1;
				}
			}else if(level2) {
				if(spaceY <= bossY+3+230) {
					spaceY += 1;
				}
			}else {
				if(spaceY <= bossY+3+165) {
					spaceY += 1;
				}
			}
		}else if(bossHealth == 0 && bossExplode != 0) {
			bossY -= 1;
		}
	}
	public void checkBossHit() {
		for(int j = 0; j < countMissiles; j++) {
			if(level3) {
				//w+200 (220-20)=max
				//w-20 = min
				int w = (this.getWidth()-220)/2-8;
				if((missilesX.get(j) <= w+30 && missilesX.get(j) >= w-10/*or -8, not sure*/ && missilesY.get(j) <= bossY + 120) || (missilesX.get(j) <= w+210 && missilesX.get(j) > w+170 && missilesY.get(j) <= bossY + 120) || (missilesX.get(j) <= w+57 && missilesX.get(j) > w+30 && missilesY.get(j) <= bossY + 80) || (missilesX.get(j) <= w+170 && missilesX.get(j) > w+142 && missilesY.get(j) <= bossY + 80) || (missilesX.get(j) <= w+142 && missilesX.get(j) > w+57 && missilesY.get(j) <= bossY + 160)) {
					missilesX.remove(j); 
					missilesY.remove(j);
					countMissiles--;
					if(bossHealth != 0) {																					//think about not doing this checking this code if the boss is defeated
						bossHit = 10;//indikator, da je bil boljši sovražnik zadet
						bossHealth--;//zmanjšamo število življenskih toèk
						if(bossHealth == 0) {//v primeru, da nima veè življenskih toèk																				/*removes any lasers if any that are present when the boss2 is defeated - my origina intentionwas also removing any bullets2 but it is better to do it on line 2115 because all of them will not be removed at the same time*/
							enemyLasersX.clear();
							enemyLasersY.clear();
							countEnemyLasers = 0;
							bossExplode = 25;
							secondary = false;
							primary = false;
						}
					}
					break;
				}
			}else if(level2) {
				int w = (this.getWidth()-230)/2-8;
				//w+210 - (230 - 20) = max
				//w-20 = min
				if((missilesX.get(j) <= w+26 && missilesX.get(j) >= w-7 && missilesY.get(j) <= bossY + 105) || (missilesX.get(j) <= w+223 && missilesX.get(j) >= w+195 && missilesY.get(j) <= bossY + 105) || (missilesX.get(j) <= w+50 && missilesX.get(j) >= w+27 && missilesY.get(j) <= bossY + 175) || (missilesX.get(j) <= w+195 && missilesX.get(j) >= w+175 && missilesY.get(j) <= bossY + 175) || (missilesX.get(j) <= w+77 && missilesX.get(j) >= w+51 && missilesY.get(j) <= bossY + 205) || (missilesX.get(j) <= w+174 && missilesX.get(j) >= w+145 && missilesY.get(j) <= bossY + 205) || (missilesX.get(j) <= w+144 && missilesX.get(j) >= w+78 && missilesY.get(j) <= bossY + 130)) {
					missilesX.remove(j); 
					missilesY.remove(j);
					countMissiles--;
					if(bossHealth != 0) {//think about not doing this checking this code if the boss is defeated
						bossHit = 10;
						bossHealth--;
						if(bossHealth == 0) {//
							/*
							 *removes any lasers if any that are present when the boss2 is defeated - my origina intention
							 *was also removing any bullets2 but it is better to do it on line 2115 because all 
							 *of them will not be removed at the same time
							*/
							enemyLasersX.clear();
							enemyLasersY.clear();
							countEnemyLasers = 0;
							bossExplode = 27;
							secondary = false;
							primary = false;
						}
					}
					break;
				}
			}else {
				int w = (this.getWidth()-270)/2-8;
				//w+250 - (270 - 20) = max
				//w-20 = min
				if((missilesX.get(j) <= w+110 && missilesX.get(j) >= w+10 && missilesY.get(j) <= bossY + 130) || (missilesX.get(j) <= w+230 && missilesX.get(j) >= w+120 && missilesY.get(j) <= bossY + 130) || (missilesX.get(j) <= w+120 && missilesX.get(j) >= w+110 && missilesY.get(j) <= bossY + 95) || (missilesX.get(j) < w+10 && missilesX.get(j) >= w-20 && missilesY.get(j) <= bossY + 80) || (missilesX.get(j) <= w+250 && missilesX.get(j) > w+230 && missilesY.get(j) <= bossY + 80)) {
					missilesX.remove(j); 
					missilesY.remove(j);
					countMissiles--;
					if(bossHealth != 0) {//think about not doing this checking this code if the boss is defeated
						bossHit = 10;
						bossHealth--;
						if(bossHealth == 0) {
							bossExplode = 20;
							secondary = false;
							primary = false;
						}
					}
					break;
				}
			}
		}
	}
	

	public void createMinions() {
		System.out.println("minions");
		if(level3) {
			for(int i = 0; i < 4; i++) {
				int num = (int) (Math.random()*2);
					if(num == 1) {
						enemyShip3X.add((int) (Math.random()*((this.getWidth()-200)/2-8-70))+220+(this.getWidth()-200)/2-8);
					}else {
						enemyShip3X.add((int) (Math.random()*((this.getWidth()-200)/2-8-70)));
					}
					enemyShip3Y.add(-50 - i*400);	
					enemyShip3Hit.add(0);
					enemyShip3Health.add(1);
					enemyShip3AttackTime.add(0);
					countEnemySpaceships3++;
			}
		}else if(level2) {
			for(int i = 0; i < 4; i++) {
				int num = (int) (Math.random()*2);
					if(num == 1) {
						enemyShip2X.add((int) (Math.random()*((this.getWidth()-230)/2-8-50))+230+(this.getWidth()-230)/2-8);
					}else {
						enemyShip2X.add((int) (Math.random()*((this.getWidth()-230)/2-8-50)));
					}
					enemyShip2Y.add(-50 - i*600);	
					enemyShip2Hit.add(0);
					enemyShip2Health.add(1);
					countEnemySpaceships2++;
			}
		}else {
			for(int i = 0; i < 4; i++) {
				int num = (int) (Math.random()*2);
					if(num == 1) {
						enemyShipX.add((int) (Math.random()*((this.getWidth()-270)/2-8-50))+270+(this.getWidth()-270)/2-8);
					}else {
						enemyShipX.add((int) (Math.random()*((this.getWidth()-270)/2-8-50)));
					}
					enemyShipY.add(-50 - i*300);	
					countEnemySpaceships++;
			}
		}
	}
	public void firePrimaryWeapon() {
		System.out.println("primary");
		if(level3) {
			enemyPlasmaBulletsX.add((this.getWidth()-220)/2-8 + 75.0);
			enemyPlasmaBulletsY.add(150.0);
			double x = enemyPlasmaBulletsX.get(countEnemyPlasmaBullets);//zaèetka X lokacija
			double y = spaceY - 120;//zaèetna Y lokacija
			if(left) {//èe se igralna figura premika levo																					//do it a little harder for up and down as well? mybe, not fure 3mnow new if not in here
				x = spaceX-75 - x;
				if(up) {//èe se igralna figura premika gor
					y -= 40;
				}
			}else if(right) {//èe se igralna figura premika desno
				x = spaceX+35 - x;
			}else {x = spaceX-10 - x;}
			double a = Math.max(Math.abs(x), Math.abs(y))/Math.min(Math.abs(x), Math.abs(y));
			if(x == 0) {a = Math.abs(y);}
			double v = Math.sqrt(16.0/(Math.pow(a, 2) + 1));//izraèun skupne hitrosti									//4.0 here --> change it if you want the bullets to be faster
			double vx = v; double vy = v;
			if(x < 0) {
				vx *= -1;
			}
			double sx, sy = 0;
			if(Math.abs(x) > y) {
				sx = a*vx; sy = vy;//doloèitev "poti", ki jo izstrelek opravi vsak repaint v smeri X
			}else {
				sy = a*vy; sx = vx;//doloèitev "poti", ki jo izstrelek opravi vsak repaint v smeri Y
			}
			deltaMovePlasmaBulletsX.add(sx); deltaMovePlasmaBulletsY.add(sy);//shranim razliko poti v obeh smereh
			countEnemyPlasmaBullets++;
			
			enemyPlasmaBulletsX.add((this.getWidth()-220)/2-8 + 139.0);
			enemyPlasmaBulletsY.add(150.0);
			x = enemyPlasmaBulletsX.get(countEnemyPlasmaBullets);
			y = spaceY - 120;
			if(left) {																						//do it a little harder for up and down as well? mybe, not fure 3mnow new if not in here
				x = spaceX+35 - x;
			}else if(right) {
				x = spaceX +90+35 - x;
				if(up) {
					y-= 40;
				}
			}else {
				x = spaceX+60 - x;
			}
			a = Math.max(Math.abs(x), Math.abs(y))/Math.min(Math.abs(x), Math.abs(y));
			if(x == 0) {
				a = Math.abs(y);
			}
																											//25.0 will be too ardh
			v = Math.sqrt(16.0/(Math.pow(a, 2) + 1));														//4.0 here --> change it if you want the bullets to be faster
			vx = v;
			vy = v;
			if(x < 0) {
				vx *= -1;
			}
			if(Math.abs(x) > y) {
				sx = a*vx;
				sy = vy;
			}else {
				sy = a*vy;
				sx = vx;
			}
			deltaMovePlasmaBulletsX.add(sx);
			deltaMovePlasmaBulletsY.add(sy);
			countEnemyPlasmaBullets++;
		}else if(level2) {
			//primary though is firing lasers i think i wanna do that
		}else {
			enemyMissilesX.add((this.getWidth()-270)/2-15);
			enemyMissilesY.add(65);
			countEnemyMissiles++;
			enemyMissilesX.add((this.getWidth()-270)/2-15+40);
			enemyMissilesY.add(105);
			countEnemyMissiles++;
			enemyMissilesX.add((this.getWidth()-270)/2-15+85);
			enemyMissilesY.add(130);
			countEnemyMissiles++;
			enemyMissilesX.add((this.getWidth()-270)/2-15+122);
			enemyMissilesY.add(60);
			countEnemyMissiles++;
			enemyMissilesX.add((this.getWidth()-270)/2-15+160);
			enemyMissilesY.add(130);
			countEnemyMissiles++;
			enemyMissilesX.add((this.getWidth()-270)/2-15+205);
			enemyMissilesY.add(105);
			countEnemyMissiles++;
			enemyMissilesX.add((this.getWidth()-270)/2-15+245);
			enemyMissilesY.add(65);
			countEnemyMissiles++;
		}
	}
	public void fireSecondaryWeapon() {
		System.out.println("secondary");
		if(level2) {//while loop to not add 2 mines that will overlap oke
			enemyBullets2X.add((this.getWidth()-230)/2+50.0);
			enemyBullets2Y.add(28.0);
			accelaration.add(-0.5);
			int posX = 0;
			int posY = 0;
			while(true) {
				boolean end = true;
				posX = (int) (Math.random()*((this.getWidth()-230)/4-40));
				posY = (int) (Math.random()*(this.getHeight()-270)+230);
				for(int i = 0; i < countEnemyBullets2; i++) {
					if(posX+40 >= delta2X.get(i) && posX <= delta2X.get(i)+40 && posY+40 >= delta2Y.get(i) && posY <= delta2Y.get(i)+40) {
						end = false;
						break;
					}
				}
				if(end) {
					break;
				}
			}
			delta2X.add(posX*1.0);
			delta2Y.add(posY*1.0);
			countEnemyBullets2++;
			enemyBullets2X.add((this.getWidth()-230)/2-70.0+220);
			enemyBullets2Y.add(28.0);
			accelaration.add(0.5);
			while(true) {
				boolean end = true;
				posX =  (int) (Math.random()*((this.getWidth()-230)/4-40)) + 230 + (this.getWidth()-230)/4 +(this.getWidth()-230)/2;
				posY = (int) (Math.random()*(this.getHeight()-270)+230);
				for(int i = 0; i < countEnemyBullets2; i++) {
					if(posX+40 >= delta2X.get(i) && posX <= delta2X.get(i)+40 && posY+40 >= delta2Y.get(i) && posY <= delta2Y.get(i)+40) {
						end = false;
						break;
					}
				}
				if(end) {
					break;
				}
			}
			delta2X.add(posX*1.0);
			delta2Y.add(posY*1.0);
			countEnemyBullets2++;
			enemyBullets2X.add((this.getWidth()-230)/2+70.0);
			enemyBullets2Y.add(76.0);
			accelaration.add(-1.0);
			while(true) {
				boolean end = true;
				posX =(int) (Math.random()*((this.getWidth()-230)/4-40)) + (this.getWidth()-230)/4;
				posY = (int) (Math.random()*(this.getHeight()-270)+230);
				for(int i = 0; i < countEnemyBullets2; i++) {
					if(posX+40 >= delta2X.get(i) && posX <= delta2X.get(i)+40 && posY+40 >= delta2Y.get(i) && posY <= delta2Y.get(i)+40) {
						end = false;
						break;
					}
				}
				if(end) {
					break;
				}
			}
			delta2X.add(posX*1.0);
			delta2Y.add(posY*1.0);
			countEnemyBullets2++;
			enemyBullets2X.add((this.getWidth()-230)/2-80.0+220);
			enemyBullets2Y.add(76.0);
			accelaration.add(1.0);
			while(true) {
				boolean end = true;
				posX = (int) (Math.random()*((this.getWidth()-230)/4-40)) + 230+(this.getWidth()-230)/2;
				posY = (int) (Math.random()*(this.getHeight()-270)+230);
				for(int i = 0; i < countEnemyBullets2; i++) {
					if(posX+40 >= delta2X.get(i) && posX <= delta2X.get(i)+40 && posY+40 >= delta2Y.get(i) && posY <= delta2Y.get(i)+40) {
						end = false;
						break;
					}
				}
				if(end) {
					break;
				}
			}
			delta2X.add(posX*1.0);
			delta2Y.add(posY*1.0);
			countEnemyBullets2++;
		}
	}
	public void createEnemyBullet() {
		enemyBulletsX.add((double) ((this.getWidth()-270)/2-15+132));
		enemyBulletsY.add(130.0);
		double x = (double) ((this.getWidth()-270)/2+115);
		x = spaceX+35 - x;
		double y = (spaceY-90);
		double a = Math.max(Math.abs(x), Math.abs(y))/Math.min(Math.abs(x), Math.abs(y));
		double t = Math.sqrt(4.0/(Math.pow(a, 2) + 1));											//4.0 here --> change it if you want the bullets to be faster
		double tx = t;
		double ty = t;
		if(x < 0) {
			tx *= -1;
		}
		double vx, vy = 0;
		if(Math.abs(x) > y) {
			vx = a*tx;
			vy = ty;
		}else {
			vy = a*ty;
			vx = tx;
		}
		
		deltaMoveX.add(vx);
		deltaMoveY.add(vy);
		countEnemyBullets++;
	}
	public void createEnemyLasers() {
		if(!positions.contains(1)) {
			enemyLasersX.add((this.getWidth()-230)/2 - 15 + 20+10);
			enemyLasersY.add(110-70+65);
			countEnemyLasers++;
		}
		if(!positions.contains(2)) {//2 here
			enemyLasersX.add((this.getWidth()-230)/2 - 15 +48+10);
			enemyLasersY.add(180-70+45);
			countEnemyLasers++;
		}
		
		if(!positions.contains(3)) {//3 here
			enemyLasersX.add((this.getWidth()-230)/2 - 15 +73+10);
			enemyLasersY.add(210-70+45);
			countEnemyLasers++;
		}
		if(!positions.contains(4)) {//4 here
			enemyLasersX.add((this.getWidth()-230)/2 - 15 + 103+10);
			enemyLasersY.add(140-70+45);
			countEnemyLasers++;
		}
		
		if(!positions.contains(5)) {// 5 here
			enemyLasersX.add((this.getWidth()-230)/2 - 15 + 152);
			enemyLasersY.add(140-70+45);
			countEnemyLasers++;
		}
		if(!positions.contains(6)) {// 6 here
			enemyLasersX.add((this.getWidth()-230)/2 - 15 + 182);
			enemyLasersY.add(210-70+45);
			countEnemyLasers++;
		}
		if(!positions.contains(7)) {// 7 here
			enemyLasersX.add((this.getWidth()-230)/2 - 15 + 207);
			enemyLasersY.add(180-70+45);
			countEnemyLasers++;
		}
		if(!positions.contains(8)) {
			enemyLasersX.add((this.getWidth()-230)/2 - 15 + 235);
			enemyLasersY.add(110-70+65);
			countEnemyLasers++;
		}
	}
	public void dronesShoot() {
		if(dronesAttackTime <= 0) {
			if(moveDrone0) {
				droneBulletsX.add(dronesX.get(0) + 20.0);
				droneBulletsY.add(dronesY.get(0) + 15.0);
				countEnemyDroneBullets++;
			}
			if(moveDrone1) {
				droneBulletsX.add(dronesX.get(1) + 20.0);
				droneBulletsY.add(dronesY.get(1) + 15.0);
				countEnemyDroneBullets++;
			}
			if(moveDrone2) {
				droneBullets2X.add(dronesX.get(2) + 5.0);
				droneBullets2Y.add(dronesY.get(2) + 15.0);
				countEnemyDroneBullets2++;
			}
			if(moveDrone3) {
				droneBullets2X.add(dronesX.get(3) + 5.0);
				droneBullets2Y.add(dronesY.get(3) + 15.0);
				countEnemyDroneBullets2++;
			}
			dronesAttackTime = 1800;
		}
	}
	

	public void moveEnemyMissiles() {
		for(int i = 0; i < countEnemyMissiles; i++) {
			int y = 0;
			if((i == 0 || i == 6 || i == 3) && countEnemyMissiles == 7) {
				y = enemyMissilesY.get(i) + 4;
			}else{
				y = enemyMissilesY.get(i) + 3;
			}
			enemyMissilesY.remove(i);
			if(y < 495) {
				enemyMissilesY.add(i, y);
			}else {
				enemyMissilesX.remove(i);
				countEnemyMissiles--;
			}
		}
	}
	public void moveEnemyBullets() {
		for(int i = 0; i < countEnemyBullets; i++) {
			double y = enemyBulletsY.get(i) + deltaMoveY.get(i);
			double x = enemyBulletsX.get(i) + deltaMoveX.get(i);
			enemyBulletsY.remove(i);
			enemyBulletsX.remove(i);
			if(y < 495 && x > -20 && x < 720) {
				enemyBulletsY.add(i, y);
				enemyBulletsX.add(i, x);
			}else {
				countEnemyBullets--;
				deltaMoveX.remove(i);
				deltaMoveY.remove(i);
			}
		}
	}
	public void moveEnemyBullets2() {
		for(int i = 0; i < countEnemyBullets2; i++) {
			double x = delta2X.get(i) - enemyBullets2X.get(i);
			double y = delta2Y.get(i) - enemyBullets2Y.get(i);
			if(Math.abs(x) > 1 || Math.abs(y) > 1) {
				double a = Math.max(Math.abs(x), Math.abs(y))/Math.min(Math.abs(x), Math.abs(y));
				double v = Math.sqrt(4.0/(Math.pow(a, 2) + 1));//4.0 here --> change it if you want the bullets to be faster
				double vx = v;
				double vy = v;
				if(x < 0) {
					vx *= -1;
				}
				if(y < 0) {
					vy *= -1;
				}
				vx += 1.3*vx;
				double sx, sy = 0;
				if(Math.abs(x) > y) {
					sx = a*vx;
					sy = vy;
				}else {
					sy = a*vy;
					sx = vx;
				}
				sx += accelaration.get(i);
				double newX = enemyBullets2X.get(i) + sx;
				double newY = enemyBullets2Y.get(i) + sy;
				enemyBullets2X.remove(i);
				enemyBullets2Y.remove(i);
				enemyBullets2X.add(i, newX);
				enemyBullets2Y.add(i, newY);
			}
		}
	}
	public void moveEnemyLasers() {
		for(int i = 0; i < countEnemyLasers; i++) {
			int y = enemyLasersY.get(i) + 3;
			enemyLasersY.remove(i);
			if(y < 495) {
				enemyLasersY.add(i, y);
			}else {
				enemyLasersX.remove(i);
				countEnemyLasers--;
			}
		}
	}
	public void moveDroneBullets() {
		for(int i = 0; i < countEnemyDroneBullets; i++) {
			double x = droneBulletsX.get(i) + 3;//idk what the speed should be? 3? 4?5? idk 5 is too much 4 idk
			droneBulletsX.remove(i);
			if(x < 725) {
				droneBulletsX.add(i, x);
			}else {
				droneBulletsY.remove(i);
				countEnemyDroneBullets--;
			}
		}
		for(int i = 0; i < countEnemyDroneBullets2; i++) {
			double x = droneBullets2X.get(i) - 3;//idk what the speed should be? 3? 4?5? idk 5 is too much 4 idk
			droneBullets2X.remove(i);
			if(x > - 20) {//don't know hw big it will be yet
				droneBullets2X.add(i, x);
			}else {
				droneBullets2Y.remove(i);
				countEnemyDroneBullets2--;
			}
		}
	}
	public void moveEnemy3Plasma() {
		for(int i = 0; i < countEnemyPlasma; i++) {
			int y = enemyPlasmaY.get(i) + 5;
			enemyPlasmaY.remove(i);
			if(y < 485) {
				enemyPlasmaY.add(i, y);
			}else {
				enemyPlasmaX.remove(i);
				countEnemyPlasma--;
			}
		}
	}
	public void moveEnemyPlasmaBullets() {
		for(int i = 0; i < countEnemyPlasmaBullets; i++) {
			double y = enemyPlasmaBulletsY.get(i) + deltaMovePlasmaBulletsY.get(i);
			double x = enemyPlasmaBulletsX.get(i) + deltaMovePlasmaBulletsX.get(i);
			enemyPlasmaBulletsY.remove(i);
			enemyPlasmaBulletsX.remove(i);
			if(y < 495 && x > -20 && x < 720) {
				enemyPlasmaBulletsY.add(i, y);
				enemyPlasmaBulletsX.add(i, x);
			}else {
				countEnemyPlasmaBullets--;
				deltaMovePlasmaBulletsX.remove(i);
				deltaMovePlasmaBulletsY.remove(i);
			}
		}
	}
	
	public void moveEnemyDrones() {
		if(moveDrone0) {
			if(secondary) {
				if(dronesX.get(0) < 0) {
					int x = dronesX.get(0)+1;
					dronesX.remove(0);
					dronesX.add(0, x);
				}
			}
		}
		if(!moveDrone0 && dronesX.get(0) > - 30) {
			int x = dronesX.get(0) - 1;
			dronesX.remove(0);
			dronesX.add(0, x);
		}
		if(moveDrone1) {
			if(secondary) {
				if(dronesX.get(1) < 0) {
					int x = dronesX.get(1)+1;
					dronesX.remove(1);
					dronesX.add(1, x);
				}
			}
		}
		if(!moveDrone1 && dronesX.get(1) > - 30) {
			int x = dronesX.get(1) - 1;
			dronesX.remove(1);
			dronesX.add(1, x);
		}
		if(moveDrone2) {
			if(secondary) {
				if(dronesX.get(2) > this.getWidth()-25) {
					int x = dronesX.get(2) - 1;
					dronesX.remove(2);
					dronesX.add(2, x);
				}
			}
		}
		if(!moveDrone2 && dronesX.get(2) < this.getWidth()+10) {
			int x = dronesX.get(2) + 1;
			dronesX.remove(2);
			dronesX.add(2, x);
		}
		if(moveDrone3){
			if(secondary) {
				if(dronesX.get(3) > this.getWidth()-25) {
					int x = dronesX.get(3) - 1;
					dronesX.remove(3);
					dronesX.add(3, x);
				}
			}
		}
		if(!moveDrone3 && dronesX.get(3) < this.getWidth()+10) {
			int x = dronesX.get(3) + 1;
			dronesX.remove(3);
			dronesX.add(3, x);
		}
	}
	public void movePowerup() {
		if(powerupY < 485) {
			powerupY += 2;
		}
	}
	public void moveSpaceImage() {
		ey = ey + 0.7;
	}
	

	public void enemyShips3Shoot() {
		for(int i = 0; i < countEnemySpaceships3; i++) {										//think about not shooting if enemySpaceship3 is below 430 or something like that pixels
			if(enemyShip3AttackTime.get(i) <= 0 && enemyShip3Y.get(i) >= -60) {					//im going to go with integer for now, but we could go with double/float later
				enemyShip3AttackTime.remove(i);
				enemyShip3AttackTime.add(i, 1500);												//balance it
				enemyPlasmaX.add(enemyShip3X.get(i)+25);
				enemyPlasmaY.add(enemyShip3Y.get(i)+30);
				countEnemyPlasma++;
			}
		}
	}
	
	public static void main(String[] args) {
		new MovingSprite();
	}
	
	public void paintComponent(Graphics g) {
		super.paintComponent(g);
		if(helpMenu) {
			showHelpMenu(g);
		}else if(controlsMenu) {
			showControlsMenu(g);
		}else if((optionsMenu && mainMenu) || (optionsMenu && gameOverMenu)) {
			showOptionsMenu(g);
		}else if(optionsMenu && pauseMenu) {
			draw(g);
			showOptionsMenu(g);
		}else if(mainMenu) {
			showMainMenu(g);
		}else if(pauseMenu) {
			draw(g);
			showPauseMenu(g);
		}else if(upgradeMenu) {
			showUpgradeMenu(g);
		}else if (gameOverMenu) {
			showGameOverMenu(g);
		}else if (winMenu) {
			showWinMenu(g);
		}else if (gameModeSelectionMenu) {
			showGameModeSelectionMenu(g);
		}else {
			if(mouseMovedX != 0 && mouseMovedY != 0) {
				mouseMovedX = 0; mouseMovedY = 0;
			}
			draw(g);
		}
	}
	public void draw(Graphics g) {
		//Risanje in premikanje slike vesolja
		int eyc = (int)ey;
		while(eyc > -725) {
			g.drawImage(space, ex, eyc, null);
			eyc -= 720;
		}
		//risanje laserja (BOSS LVL2 primary attack)
		for(int i = 0; i < countEnemyLasers; i++) {
			g.drawImage(enemyLaser, enemyLasersX.get(i), enemyLasersY.get(i), null);
		}
		//risanje raket(metki) igralca
		for(int i = 0; i < countMissiles; i++) {
			g.drawImage(missile, missilesX.get(i), missilesY.get(i), 40, 40, null);
		}
		//risanje metkov dronov, ki se premikajo v ENI smeri -> enemy type 3
		for(int i = 0; i < countEnemyDroneBullets; i++) {
			double x = droneBulletsX.get(i); int xd = (int)x;
			double y = droneBulletsY.get(i); int yd = (int)y;
			g.drawImage(droneBullet1, xd, yd, null);
		}
		//risanje metkov dronov, ki se premikajo v DRUGI smeri -> enemy type 3
		for(int i = 0; i < countEnemyDroneBullets2; i++) {
			double x = droneBullets2X.get(i); int xd = (int)x;
			double y = droneBullets2Y.get(i); int yd = (int)y;
			g.drawImage(droneBullet2, xd, yd, null);
		}
		//èe smo v levelu 3 -> narišemo 4 drone 2 na levi in 2 na desni
		if(level3) {
			for(int i = 0; i < 4; i++) {
				if(i < 2) {
					g.drawImage(boss3SecondaryDrone1, dronesX.get(i), dronesY.get(i), null);
				}else {
					g.drawImage(boss3SecondaryDrone2, dronesX.get(i), dronesY.get(i), null);
				}
			}
		}
		//risanje enemy type 1
		for(int i = 0; i < countEnemySpaceships; i++) {
			g.drawImage(enemyShip, enemyShipX.get(i),enemyShipY.get(i), 50, 50, null);
		}
		//risanje enemy type 2
		for(int i = 0; i < countEnemySpaceships2; i++) {
			if(enemyShip2Hit.get(i) > 0) {
				g.drawImage(enemyShip2IsHit, enemyShip2X.get(i),enemyShip2Y.get(i), null);
				int x = enemyShip2Hit.get(i);
				if(!pauseMenu) {
					enemyShip2Hit.remove(i);
					x--;
					enemyShip2Hit.add(i, x);
				}
			}else {
				g.drawImage(enemyShip2, enemyShip2X.get(i),enemyShip2Y.get(i), null);
			}
		}
		//risanje metkov(enemy type 3)
		for(int i = 0; i < countEnemyPlasma; i++) {
			g.drawImage(enemy3Plasma, enemyPlasmaX.get(i), enemyPlasmaY.get(i), null);
		}
		//risanje enemy type 3
		for(int i = 0; i < countEnemySpaceships3; i++) {
			if(enemyShip3Hit.get(i) > 0) {
				g.drawImage(enemyShip3IsHit, enemyShip3X.get(i),enemyShip3Y.get(i), null);
				int x = enemyShip3Hit.get(i);
				if(!pauseMenu) {
					enemyShip3Hit.remove(i);
					x--;
					enemyShip3Hit.add(i, x);
				}
			}else {
				g.drawImage(enemyShip3, enemyShip3X.get(i),enemyShip3Y.get(i), null);
			}
		}
		//risanje raket(BOSS LVL1 primary attack)
		for(int i = 0; i < countEnemyMissiles; i++) {
			g.drawImage(enemyMissile, enemyMissilesX.get(i), enemyMissilesY.get(i), 40, 40, null);
		}
		//risanje metkov(BOSS LVL1 secondary attack)
		for(int i = 0; i < countEnemyBullets; i++) {
			double x = enemyBulletsX.get(i);
			int xd = (int)x;
			double y = enemyBulletsY.get(i);
			int yd = (int)y;
			g.drawImage(enemyBullet, xd, yd, 20, 20, null);
		}
		//risanje min (BOSS LVL2 secondary attack)
		for(int i = 0; i < countEnemyBullets2; i++) {
			double x = enemyBullets2X.get(i);
			int xd = (int)x;
			double y = enemyBullets2Y.get(i);
			int yd = (int)y;
			g.drawImage(enemyBullet2, xd, yd, 40, 40, null);
		}
		//risanje plasma metkov (BOSS LVL3 primary attack)
		for(int i = 0; i < countEnemyPlasmaBullets; i++) {
			double x = enemyPlasmaBulletsX.get(i);
			int xd = (int)x;
			double y = enemyPlasmaBulletsY.get(i);
			int yd = (int)y;
			g.drawImage(enemyPlasmaBullet, xd, yd, null);
		}
		//èe je powerup še na zaslonu, ga nariše
		if(powerupY > -80 && powerupY < 485) {
			g.drawImage(selectedPowerup, powerupX, powerupY, null);
		}
		//risanje življenj
		for(int i = 0; i < halfLives; i++) {
			if(i % 2 == 0) {
				g.drawImage(halfLife1, i*12 , 0, 20, 20, null);
			}else {
				g.drawImage(halfLife2, (i-1)*12 , 0, 20, 20, null);
			}
		}
		//risanje dodatnih "življenj"
		for(int i = 0; i < shields; i++) {
			g.drawImage(shield, i*20 , 20, null);
		}
		//èe je bil igralec nedavno zadet, riši rdeèkasto sliko ladje in zmanjšas playerHit za 1 
		//-> nekaj èasa je vidna barva zaradi tega
		if(yourShipHit > 0) {//drawing ship
			g.drawImage(spaceshipHit, spaceX, spaceY, null);
			if(!pauseMenu) {
				yourShipHit--;
			}
		}else{//èe pa ne pa nariši normalno sliko ladje
			g.drawImage(spaceship, spaceX, spaceY, null);
		}
		//èe je boss in je level3
		if(boss && level3) {
			//èe je bil boss nedavno zadet... tko kot pr playerju
			if(bossHit > 0) {
				g.drawImage(enemyBoss3Hit, (this.getWidth()-200)/2 - 8, (int)bossY, null);
				if(!pauseMenu) {
					bossHit--;
				}
			}else {
				g.drawImage(enemyBoss3, (this.getWidth()-200)/2 - 8, (int)bossY, null);
			}
		//enako kot za boss3
		}else if(boss && level2) {
			if(bossHit > 0) {
				g.drawImage(enemyBoss2Hit, (this.getWidth()-200)/2 - 8, (int)bossY, null);//230 here but then have to change more stuff...fix later
				if(!pauseMenu) {
					bossHit--;
				}
			}else {
				g.drawImage(enemyBoss2, (this.getWidth()-200)/2 - 8, (int)bossY, null);//230 here but then have to change more stuff...fix later
			}
		//enako kot boss3
		}else if(boss){
			if(bossHit > 0) {
				g.drawImage(enemyBossHit, (this.getWidth()-270)/2 - 8, (int)bossY, null);
				if(!pauseMenu) {
					bossHit--;
				}
			}else {
				g.drawImage(enemyBoss, (this.getWidth()-270)/2 - 8, (int)bossY, null);
			}
		}
		//èe je boss v fazi eksplodiranja (ko nima veè življenja) in je LVL 3
		if(bossExplode > 0 && level3) {
			g.drawImage(enemyBoss3, (this.getWidth()-200)/2 - 8, (int)bossY, null);
			if(!pauseMenu && !wait) {
				explosionsBossX.add((this.getWidth()-200)/2 - 8 + (int) ((Math.random()*31) + 75));
				explosionsBossY.add((int) ((Math.random()*76) + 20 + bossY));
				howManyRepaintsBoss.add(8);
				bossExplode --;
				countExplosionsBoss++;
				wait = true;
			}
		//èe je boss v fazi eksplodiranja (ko nima veè življenja) in je LVL 2
		}else if(bossExplode > 0 && level2) {
			g.drawImage(enemyBoss2, (this.getWidth()-200)/2 - 8, (int)bossY, null);
			if(!pauseMenu && !wait) {
				explosionsBossX.add((this.getWidth()-200)/2 - 8 + (int) ((Math.random()*31) + 85));
				explosionsBossY.add((int) ((Math.random()*61) + 34 + bossY));
				howManyRepaintsBoss.add(8);
				bossExplode --;
				countExplosionsBoss++;
				wait = true;
			}
		//èe je boss v fazi eksplodiranja (ko nima veè življenja) in je LVL 1
		}else if(bossExplode > 0){
			g.drawImage(enemyBoss, (this.getWidth()-270)/2 - 8, (int)bossY, null);
			if(!pauseMenu && !wait) {
				explosionsBossX.add((this.getWidth()-270)/2 - 8 + (int) ((Math.random()*121) + 50));
				explosionsBossY.add((int) ((Math.random()*51) + 34 + bossY));
				howManyRepaintsBoss.add(8);
				bossExplode --;
				countExplosionsBoss++;
				wait = true;
			}
		}
		//risanje eksplozij --> v bistvu simularimo animacijo (približno)
		for(int i = 0; i < countExplosions; i++) {
				//èe je število risanj te eksplozije, ki jih želimo opraviti > 0
				if(howManyRepaints.get(i) != 0) {
					//èe je število risanj te eksplozije > 4 rišemo le-to veèjo
					if(howManyRepaints.get(i) > 4) {
							//rišemo sovražnika, ki je bil unièen s pomoèjo enemyType-a -> 
							//nam pove kateri je bil
							if(enemyType.get(i) == 1) {
								g.drawImage(enemyShip, explosionsX.get(i),explosionsY.get(i), null);
							}else if(enemyType.get(i) == 2) {
								g.drawImage(enemyShip2, explosionsX.get(i),explosionsY.get(i), null);
							}else if(enemyType.get(i) == 3) {
								g.drawImage(enemyShip3, explosionsX.get(i),explosionsY.get(i), null);
							}
							if(enemyType.get(i) == 3) {																	//choose whichever you prefer this or writing this in every if sentence/else
								g.drawImage(explosion, explosionsX.get(i)+15,explosionsY.get(i)+5+5, 40, 40, null);
							}else {
								g.drawImage(explosion, explosionsX.get(i)+5,explosionsY.get(i)+5, 40, 40, null);
							}
					//èe je število risanj te eksplozije > 2 rišemo le-to nekoliko manjšo
					}else if(howManyRepaints.get(i) > 2) {
						
						if(enemyType.get(i) == 3) {																							//choose whichever you prefer
							g.drawImage(explosion, explosionsX.get(i)+19,explosionsY.get(i)+9+5, 33, 33, null);
						}else {
							g.drawImage(explosion, explosionsX.get(i)+9,explosionsY.get(i)+9, 33, 33, null);
						}
					//drugaèe pa rišemo eksplozijo še manjšo	
					}else{
						if(enemyType.get(i) == 3) {//choose whichever you prefer
							g.drawImage(explosion, explosionsX.get(i)+22,explosionsY.get(i)+12+5, 26, 26, null);
						}else {
							g.drawImage(explosion, explosionsX.get(i)+12,explosionsY.get(i)+12, 26, 26, null);
						}
					}
					//èe trenutno igra ni zaustavljena in je v pause meniju zmanjšamo število
					//ponovitev eksplozije za to eksplozijo
					if(!pauseMenu) {
						int count = howManyRepaints.get(i);
						count--;
						howManyRepaints.remove(i);
						howManyRepaints.add(i, count);
					}
				//èe je število ponovitev eksplozije za to eksplozijo 0, potem jo izbrišemo
				}else {
					//if any errors dej tle pol if !pauseMenu ampak se mi zdi da n bo nè ane
						howManyRepaints.remove(i);
						explosionsX.remove(i);
						explosionsY.remove(i);
						enemyType.remove(i);
						countExplosions--;
				}
		}
		
		//risanje eksplozij boljšega sovražnika --> wait nastavimo na true, da jih narišemo, ko pa  gre
		//dol s screena oz. je število ponovitev eksplozij = 0, nastavimo wait nazaj na false
		//za normalno delovanje igre
		if(wait) {
			for(int i = 0; i < countExplosionsBoss; i++) {
				if(howManyRepaintsBoss.get(i) != 0) {
					if(howManyRepaintsBoss.get(i) > 4) {
						g.drawImage(explosion, explosionsBossX.get(i)+5,explosionsBossY.get(i)+5, 40, 40, null);
					}else if(howManyRepaintsBoss.get(i) > 2) {
						g.drawImage(explosion, explosionsBossX.get(i)+9,explosionsBossY.get(i)+9, 33, 33, null);
					}else{
						g.drawImage(explosion, explosionsBossX.get(i)+12,explosionsBossY.get(i)+12, 26, 26, null);
					}	
					if(!pauseMenu) {
						int count = howManyRepaintsBoss.get(i);
						count--;
						howManyRepaintsBoss.remove(i);
						howManyRepaintsBoss.add(i, count);
					}
				}else {
						howManyRepaintsBoss.remove(i);
						explosionsBossX.remove(i);
						explosionsBossY.remove(i);
						countExplosionsBoss--;
						//i = -1;
						wait = false;
				}
			}
		}
		for(int i = 0; i < countBullets2Explosions; i++) {
			double dx = explosionsBullets2X.get(i);
			int x = (int) dx;
			double dy = explosionsBullets2Y.get(i);
			int y = (int) dy;
			if(enemyBullets2howManyRepaints.get(i) != 0) {
				if(enemyBullets2howManyRepaints.get(i) > 4) {
						g.drawImage(enemyBullet2, x,y, 40, 40, null);
						g.drawImage(explosion,x+5,y+5, 30, 30, null);
				}else if(enemyBullets2howManyRepaints.get(i) > 2) {
					g.drawImage(explosion, x+9,y+9, 23, 23, null);
				}else{
					g.drawImage(explosion, x+12,y+12, 16, 16, null);
				}	
				if(!pauseMenu) {
					int count = enemyBullets2howManyRepaints.get(i);
					count--;
					enemyBullets2howManyRepaints.remove(i);
					enemyBullets2howManyRepaints.add(i, count);
				}
			}else {
				//if any errors dej tle pol if !pauseMenu ampak se mi zdi da n bo nè ane
					enemyBullets2howManyRepaints.remove(i);
					explosionsBullets2X.remove(i);
					explosionsBullets2Y.remove(i);
					countBullets2Explosions--;
			}
	}
		g.drawImage(scoreIndicator, 530, 0, null);
		g.setColor(Color.WHITE);
		g.setFont(new Font(null, 80, 30));
		g.drawString(""+score, 610, 25);
	}
	

	public void showGameModeSelectionMenu(Graphics g){
		if(mouseMovedX >= (f.getWidth()-640)/2 && mouseMovedX <= (f.getWidth()-640)/2+640 && mouseMovedY >= 25+31 && mouseMovedY <= 120+31) {
			g.drawImage(campaignButtonHover, (f.getWidth()-640)/2-8, 25, null);
			g.drawImage(survivalButton, (f.getWidth()-577)/2-8, 150, null);
			g.drawImage(exitButton, (f.getWidth()-245)/2-8, 270, null);
		}else if(mouseMovedX >= (f.getWidth()-577)/2 && mouseMovedX <= (f.getWidth()-577)/2+577 && mouseMovedY >= 150+31 && mouseMovedY <= 245+31) {
			g.drawImage(campaignButton, (f.getWidth()-640)/2-8, 25, null);
			g.drawImage(survivalButtonHover, (f.getWidth()-577)/2-8, 150, null);
			g.drawImage(exitButton, (f.getWidth()-245)/2-8, 270, null);
		}else if(mouseMovedX >= (f.getWidth()-245)/2 && mouseMovedX <= (f.getWidth()-245)/2+245 && mouseMovedY >= 270+31 && mouseMovedY <= 365+31) {
			g.drawImage(campaignButton, (f.getWidth()-640)/2-8, 25, null);
			g.drawImage(survivalButton, (f.getWidth()-577)/2-8, 150, null);
			g.drawImage(exitButtonHover, (f.getWidth()-245)/2-8, 270, null);
		}else {
			g.drawImage(campaignButton, (f.getWidth()-640)/2-8, 25, null);
			g.drawImage(survivalButton, (f.getWidth()-577)/2-8, 150, null);
			g.drawImage(exitButton, (f.getWidth()-245)/2-8, 270, null);
		}
	}
	public void showMainMenu(Graphics g) {
		//add an image thats gonna be repeating and making a visual effect of an environment that's actually moving
		if(mouseMovedX >= (f.getWidth()-310)/2 && mouseMovedX <= (f.getWidth()-310)/2+310 && mouseMovedY >= 25+31 && mouseMovedY <= 120+31) {
			g.drawImage(playButtonHover, (f.getWidth()-310)/2-8, 25, null);
			g.drawImage(optionsButton, (f.getWidth()-520)/2-8, 150, null);
			g.drawImage(backButton, (f.getWidth()-323)/2-8, 270, null);
		}else if(mouseMovedX >= (f.getWidth()-520)/2 && mouseMovedX <= (f.getWidth()-520)/2+520 && mouseMovedY >= 150+31 && mouseMovedY <= 245+31) {
			g.drawImage(playButton, (f.getWidth()-310)/2-8, 25, null);
			g.drawImage(optionsButtonHover, (f.getWidth()-520)/2-8, 150, null);
			g.drawImage(backButton, (f.getWidth()-323)/2-8, 270, null);
		}else if(mouseMovedX >= (f.getWidth()-323)/2 && mouseMovedX <= (f.getWidth()-323)/2+323 && mouseMovedY >= 270+31 && mouseMovedY <= 365+31) {
			g.drawImage(playButton, (f.getWidth()-310)/2-8, 25, null);
			g.drawImage(optionsButton, (f.getWidth()-520)/2-8, 150, null);
			g.drawImage(backButtonHover, (f.getWidth()-323)/2-8, 270, null);
		}else {
			g.drawImage(playButton, (f.getWidth()-310)/2-8, 25, null);
			g.drawImage(optionsButton, (f.getWidth()-520)/2-8, 150, null);
			g.drawImage(backButton, (f.getWidth()-323)/2-8, 270, null);
		}
	}
	public void showPauseMenu(Graphics g) {
		if(mouseMovedX >= (f.getWidth()-463)/2 && mouseMovedX <= (f.getWidth()-463)/2+463 && mouseMovedY >= 25+31 && mouseMovedY <= 120+31) {
			g.drawImage(resumeButtonHover, (f.getWidth()-463)/2-8, 25,  null);
			g.drawImage(optionsButton, (f.getWidth()-520)/2-8, 150, null);
			g.drawImage(mainMenuButton, (f.getWidth()-693)/2-8, 270, null);
		}else if(mouseMovedX >= (f.getWidth()-520)/2 && mouseMovedX <= (f.getWidth()-520)/2+520 && mouseMovedY >= 150+31 && mouseMovedY <= 245+31) {
			g.drawImage(resumeButton, (f.getWidth()-463)/2-8, 25,  null);
			g.drawImage(optionsButtonHover, (f.getWidth()-520)/2-8, 150, null);
			g.drawImage(mainMenuButton, (f.getWidth()-693)/2-8, 270, null);
		}else if(mouseMovedX >= (f.getWidth()-693)/2 && mouseMovedX <= (f.getWidth()-693)/2+693 && mouseMovedY >= 270+31 && mouseMovedY <= 365+31) {
			g.drawImage(resumeButton, (f.getWidth()-463)/2-8, 25,  null);
			g.drawImage(optionsButton, (f.getWidth()-520)/2-8, 150, null);
			g.drawImage(mainMenuButtonHover, (f.getWidth()-693)/2-8, 270, null);
		}else {
			g.drawImage(resumeButton, (f.getWidth()-463)/2-8, 25,  null);
			g.drawImage(optionsButton, (f.getWidth()-520)/2-8, 150, null);
			g.drawImage(mainMenuButton, (f.getWidth()-693)/2-8, 270, null);
		}
	}
	public void showOptionsMenu(Graphics g) {
		if(mouseMovedX >= (f.getWidth()-313)/2 && mouseMovedX <= (f.getWidth()-313)/2+313 && mouseMovedY >= 25+31 && mouseMovedY <= 120+31) {
			g.drawImage(helpButtonHover, (f.getWidth()-313)/2-8, 25,  null);
			g.drawImage(controlsButton, (f.getWidth()-633)/2-8, 150, null);
			g.drawImage(backButton, (f.getWidth()-322)/2-8, 270, null);
		}else if(mouseMovedX >= (f.getWidth()-633)/2 && mouseMovedX <= (f.getWidth()-633)/2+633 && mouseMovedY >= 150+31 && mouseMovedY <= 245+31) {
			g.drawImage(helpButton, (f.getWidth()-313)/2-8, 25,  null);
			g.drawImage(controlsButtonHover, (f.getWidth()-633)/2-8, 150, null);
			g.drawImage(backButton, (f.getWidth()-322)/2-8, 270, null);
		}else if(mouseMovedX >= (f.getWidth()-322)/2 && mouseMovedX <= (f.getWidth()-322)/2+322 && mouseMovedY >= 270+31 && mouseMovedY <= 365+31) {
			g.drawImage(helpButton, (f.getWidth()-313)/2-8, 25,  null);
			g.drawImage(controlsButton, (f.getWidth()-633)/2-8, 150, null);
			g.drawImage(backButtonHover, (f.getWidth()-322)/2-8, 270, null);
		}else {
			g.drawImage(helpButton, (f.getWidth()-313)/2-8, 25,  null);
			g.drawImage(controlsButton, (f.getWidth()-633)/2-8, 150, null);
			g.drawImage(backButton, (f.getWidth()-322)/2-8, 270, null);
		}
	}
	public void showHelpMenu(Graphics g) {
		if(mouseMovedX >= 8 && mouseMovedX <= 130+8 && mouseMovedY >= 5+31 && mouseMovedY <= 45+31) {
			g.drawImage(backButtonHover, 0, 5, 130, 40,  null);
		}else {
			g.drawImage(backButton, 0, 5, 130, 40,  null);
		}
		g.drawImage(instructionsMovement, (f.getWidth()-677)/2-8, 60, null);
		g.drawImage(instructionsShooting, (f.getWidth()-505)/2-8, 160, null);
		g.drawImage(instructionsUpgrading, (f.getWidth()-674)/2-8, 265, null);
		g.drawImage(instructionsLives, (f.getWidth()-710)/2-8, 390, null);
		g.drawImage(spaceshipRight, (f.getWidth()-677/3)/2-68 + helpMovementPixels, 100, 50, 50, null);
		g.setColor(Color.CYAN);
		g.fillRect((f.getWidth()-677/3)/2-68, 100, 50, 50);
		g.fillRect((f.getWidth()-677/3)/2-68+300, 100, 50, 50);
		g.drawImage(missileRight, (f.getWidth()-677/3)/2-54 + helpShootingPixels, 214, 22, 22, null);
		g.drawImage(spaceshipRight, (f.getWidth()-677/3)/2-68, 200, 50, 50, null);
		g.fillRect((f.getWidth()-677/3)/2-54+348, 213, 26, 22);
		
		if(helpMovementPixels >= 300) {
			helpMovementPixels = 0;
		}else {
			helpMovementPixels += 2;
		}
		if(helpShootingPixels >= 348) {
			helpShootingPixels = 0;
		}else {
			helpShootingPixels += 3;
		}
		
	}
	public void showControlsMenu(Graphics g) {
		if(mouseMovedX >= 8 && mouseMovedX <= 130+8 && mouseMovedY >= 5+33 && mouseMovedY <= 45+31) {
			g.drawImage(backButtonHover, 0, 5, 130, 40,  null);
		}else {
			g.drawImage(backButton, 0, 5, 130, 40,  null);
		}
		g.drawImage(instructionsUp, 0, 60, null);
		g.drawImage(instructionsLeft, 0, 145, null);
		g.drawImage(instructionsDown, 0, 230, null);
		g.drawImage(instructionsRight, 0, 315, null);
		g.drawImage(instructionsPause, 1, 400, null);
		g.drawImage(instructionsSpace, 375, 60, null);
		g.drawImage(instructionsUpgrade, 375, 145, null);
	}
	public void showGameOverMenu(Graphics g) {
		if(mouseMovedX >= (f.getWidth()-375)/2 && mouseMovedX <= (f.getWidth()-375)/2+375 && mouseMovedY >= 25+31 && mouseMovedY <= 120+31) {
			g.drawImage(retryButtonHover, (f.getWidth()-375)/2-8, 25,  null);
			g.drawImage(optionsButton, (f.getWidth()-520)/2-8, 150, null);
			g.drawImage(mainMenuButton, (f.getWidth()-693)/2-8, 270, null);
		}else if(mouseMovedX >= (f.getWidth()-520)/2 && mouseMovedX <= (f.getWidth()-520)/2+520 && mouseMovedY >= 150+31 && mouseMovedY <= 245+31) {
			g.drawImage(retryButton, (f.getWidth()-375)/2-8, 25,  null);
			g.drawImage(optionsButtonHover, (f.getWidth()-520)/2-8, 150, null);
			g.drawImage(mainMenuButton, (f.getWidth()-693)/2-8, 270, null);
		}else if(mouseMovedX >= (f.getWidth()-693)/2 && mouseMovedX <= (f.getWidth()-693)/2+693 && mouseMovedY >= 270+31 && mouseMovedY <= 365+31) {
			g.drawImage(retryButton, (f.getWidth()-375)/2-8, 25,  null);
			g.drawImage(optionsButton, (f.getWidth()-520)/2-8, 150, null);
			g.drawImage(mainMenuButtonHover, (f.getWidth()-693)/2-8, 270, null);
		}else {
			g.drawImage(retryButton, (f.getWidth()-375)/2-8, 25,  null);
			g.drawImage(optionsButton, (f.getWidth()-520)/2-8, 150, null);
			g.drawImage(mainMenuButton, (f.getWidth()-693)/2-8, 270, null);
		}
	}
	public void showUpgradeMenu(Graphics g) {
		if(mouseMovedX >= 8 && mouseMovedX <= 145+8 && mouseMovedY >= 5+33 && mouseMovedY <= 37+31) {
			g.drawImage(resumeSmallHover, 0, 0, null);
		}else {
			g.drawImage(resumeSmall, 0, 0, null);
		}
		if((mouseMovedX >= 280+8 && mouseMovedX <= 280+7+70 && mouseMovedY >= 32+5+28 && mouseMovedY <= 40+70+23) && healthUpgraded < 5) {
			g.drawImage(upgradeHover, 280, 34, null);
		}else if(healthUpgraded < 5){
			g.drawImage(upgrade, 280, 34, null);
		}else {
			g.drawImage(maxUpgrade, 280, 34, null);
		}
		if((mouseMovedX >= 305+8 && mouseMovedX <= 305+7+70 && mouseMovedY >= 117+5+28 && mouseMovedY <= 115+70+23) && fireRateUpgraded < 5) {
			g.drawImage(upgradeHover, 305, 109, null);
		}else if(fireRateUpgraded < 5){
			g.drawImage(upgrade, 305, 109, null);
		}else {
			g.drawImage(maxUpgrade, 305, 109, null);
		}
		
		//hya
		if((mouseMovedX >= 400+8 && mouseMovedX <= 400+7+70 && mouseMovedY >= 182+5+28 && mouseMovedY <= 182+70+28) && movementSpeedUpgraded < 3) {
			g.drawImage(upgradeHover, 400, 184, null);
		}else if(movementSpeedUpgraded < 3){
			g.drawImage(upgrade, 400, 184, null);
		}else {
			g.drawImage(maxUpgrade, 400, 184, null);
		}
		if((mouseMovedX >= 375+8 && mouseMovedX <= 375+7+70 && mouseMovedY >= 257+5+28 && mouseMovedY <= 257+70+28) && !hullReinforced) {
			g.drawImage(upgradeHover, 375, 259, null);
		}else if(!hullReinforced){
			g.drawImage(upgrade, 375, 259, null);
		}else {
			g.drawImage(maxUpgrade, 375, 259, null);
		}
		if((mouseMovedX >= 330+8 && mouseMovedX <= 330+7+70 && mouseMovedY >= 332+5+28 && mouseMovedY <= 332+70+28) && !reducedEnemyDamage) {
			g.drawImage(upgradeHover, 330, 334, null);
		}else if(!reducedEnemyDamage){
			g.drawImage(upgrade, 330, 334, null);
		}else {
			g.drawImage(maxUpgrade, 330, 334, null);
		}
		
		
		g.drawImage(healthUpgrade, 0, 50,  null);
		g.drawImage(fireRateUpgrade, 0, 125, null);
		g.drawImage(movementSpeedUpgrade, 0, 200, null);
		g.drawImage(hullReinforcementUpgrade, 0, 275,  null);
		g.drawImage(enemyDamageDowngrade, 0, 350, null);
		for(int i = 0; i < 5; i++) {
			if(i < healthUpgraded) {
				g.drawImage(upgraded, 135 + 25*i, 41,  null);
			}else {
				g.drawImage(notUpgraded, 135+ 25*i, 41,  null);
			}
			if(i < fireRateUpgraded) {
				g.drawImage(upgraded, 160+ 25*i, 116,  null);
			}else {
				g.drawImage(notUpgraded, 160+ 25*i, 116,  null);
			}
		}
		for(int i = 0; i < 3; i++) {
			if(i < movementSpeedUpgraded) {
				g.drawImage(upgraded, 305+ 25*i, 191,  null);
			}else {
				g.drawImage(notUpgraded, 305+ 25*i, 191,  null);
			}
		}
		if(hullReinforced) {
			g.drawImage(upgraded, 330, 266,  null);
		}else {
			g.drawImage(notUpgraded, 330, 266,  null);
		}
		if(reducedEnemyDamage) {
			g.drawImage(upgraded, 285, 341,  null);
		}else {
			g.drawImage(notUpgraded, 285, 341,  null);
		}
		//new - scoreIndicator
		g.drawImage(scoreIndicator, 530, 0, null);
		g.setColor(Color.WHITE);
		g.setFont(new Font(null, 80, 30));
		g.drawString(""+score, 610, 25);
		
		//new - narjeno - HEALTH
		if(healthUpgraded < 5) {
			g.drawImage(costIndicator, 380, 55, null);
			if(healthUpgradeCost <= score) {
				g.setColor(Color.GREEN);
			}else {
				g.setColor(Color.RED);
			}
			g.setFont(new Font(null, 80, 30));
			g.drawString(""+healthUpgradeCost, 455, 80);
		}
		
		//new - narjeno - FIRE RATE
		if(fireRateUpgraded < 5) {
			g.drawImage(costIndicator, 405, 130, null);
			if(fireRateUpgradeCost <= score) {
				g.setColor(Color.GREEN);
			}else {
				g.setColor(Color.RED);
			}
			g.setFont(new Font(null, 80, 30));
			g.drawString(""+fireRateUpgradeCost, 480, 155);
		}
		
		//new - NARJENO - MOVEMENT SPEED
		if(movementSpeedUpgraded < 3) {
			g.drawImage(costIndicator, 500, 205, null);
			if(movementSpeedUpgradeCost <= score) {
				g.setColor(Color.GREEN);
			}else {
				g.setColor(Color.RED);
			}
			g.setFont(new Font(null, 80, 30));
			g.drawString(""+movementSpeedUpgradeCost, 575, 230);
		}
		
		//new - ANRJENO - HULL REINFORCEMENT
			if(!hullReinforced) {
				g.drawImage(costIndicator, 475, 280, null);
			if(hullReinforcementCost <= score) {
				g.setColor(Color.GREEN);
			}else {
				g.setColor(Color.RED);
			}
			g.setFont(new Font(null, 80, 30));
			g.drawString(""+hullReinforcementCost, 550, 305);
		}
			
		//new - NARJENO - REDUCE ENEMY DAMAGE
		if(!reducedEnemyDamage) {
			g.drawImage(costIndicator, 430, 355, null);
			if(reduceEnemyDamageCost <= score) {
				g.setColor(Color.GREEN);
			}else {
				g.setColor(Color.RED);
			}
			g.setFont(new Font(null, 80, 30));
			g.drawString(""+reduceEnemyDamageCost, 505, 380);
		}
	}
	public void showWinMenu(Graphics g) {
		
	}
	
	
	@Override
	public void keyPressed(KeyEvent e) {
		if((e.getKeyCode() == KeyEvent.VK_ESCAPE || e.getKeyCode() == KeyEvent.VK_P) && !optionsMenu && !upgradeMenu && !mainMenu && !gameOverMenu && !gameModeSelectionMenu) {
			if(pauseMenu){
				f.removeMouseListener(this); f.removeMouseMotionListener(this);
				pauseMenu = false;
				menuTimer.stop();
				t.start();
				if(timerPauseAmount > 0) {
					shipTimer.setInitialDelay(timerPauseAmount);
				}
				if(difficultyTimerInitialAmount > 0) {
					difficultyTimer.setInitialDelay(difficultyTimerInitialAmount);
				}
				if(bossAbilityTimeInitialAmount> 0) {
					bossAbilityTimer.setInitialDelay(bossAbilityTimeInitialAmount);
				}
				if(powerupTimeInitialAmount > 0) {
					powerupTimer.setInitialDelay(bossAbilityTimeInitialAmount);
				}
				bossAbilityTimer.start();
				powerupTimer.start();
				shipTimer.start();
				difficultyTimer.start();
			}else {
				f.addMouseListener(this);
				f.addMouseMotionListener(this);
				pauseMenu = true;
				t.stop(); shipTimer.stop(); difficultyTimer.stop(); bossAbilityTimer.stop(); powerupTimer.stop();
				menuTimer.start();
			}
		}
		if((e.getKeyCode() == KeyEvent.VK_U && !mainMenu && !pauseMenu && !gameOverMenu && !gameModeSelectionMenu && !campaignMode && !winMenu) || (e.getKeyCode() == KeyEvent.VK_ESCAPE && upgradeMenu)) {
			if(upgradeMenu){
				f.removeMouseListener(this);
				f.removeMouseMotionListener(this);
				upgradeMenu = false;
				menuTimer.stop();
				t.start();
				if(timerPauseAmount > 0) {
					shipTimer.setInitialDelay(timerPauseAmount);
				}
				if(difficultyTimerInitialAmount > 0) {
					difficultyTimer.setInitialDelay(difficultyTimerInitialAmount);
				}
				if(powerupTimeInitialAmount > 0) {
					powerupTimer.setInitialDelay(bossAbilityTimeInitialAmount);
				}
				powerupTimer.start();
				shipTimer.start();
				difficultyTimer.start();
			}else {
				f.addMouseListener(this);
				f.addMouseMotionListener(this);
				upgradeMenu = true;
				t.stop(); shipTimer.stop(); powerupTimer.stop(); difficultyTimer.stop();
				menuTimer.start();
			}
		}
		if(e.getKeyCode() == KeyEvent.VK_LEFT || e.getKeyCode() == KeyEvent.VK_A) {
			left = true;
		}else if(e.getKeyCode() == KeyEvent.VK_RIGHT || e.getKeyCode() == KeyEvent.VK_D) {
			right = true;
		}else if(e.getKeyCode() == KeyEvent.VK_UP || e.getKeyCode() == KeyEvent.VK_W) {
			up = true;
		}else if(e.getKeyCode() == KeyEvent.VK_DOWN || e.getKeyCode() == KeyEvent.VK_S) {
			down = true;
		}else if(e.getKeyCode() == KeyEvent.VK_SPACE) {
			spacebar = true;
		}
		
	}
	public void keyReleased(KeyEvent e) {
		if(e.getKeyCode() == KeyEvent.VK_LEFT || e.getKeyCode() == KeyEvent.VK_A) {
			left = false;
		}else if(e.getKeyCode() == KeyEvent.VK_RIGHT || e.getKeyCode() == KeyEvent.VK_D) {
			right = false;
		}else if(e.getKeyCode() == KeyEvent.VK_UP || e.getKeyCode() == KeyEvent.VK_W) {
			up = false;
		}else if(e.getKeyCode() == KeyEvent.VK_DOWN || e.getKeyCode() == KeyEvent.VK_S) {
			down = false;
		}else if(e.getKeyCode() == KeyEvent.VK_SPACE) {
			spacebar = false;
		}
	}
	public void keyTyped(KeyEvent arg0) {}

	@Override//change the time of increasing difficulty
	public void actionPerformed(ActionEvent e) {
		if(!gameModeSelectionMenu && !mainMenu && !pauseMenu && !controlsMenu && !optionsMenu && !helpMenu && !gameOverMenu && !upgradeMenu && !winMenu) {
			if(survivalMode) {
				if(e.getSource() == shipTimer) {
					if(time == 20) {
						time = 3000; shipTimer.setDelay(time);
					}else {
						timerPauseAmount = 3000;
						byte num = (byte) (Math.random()*amount);
						if(num < 3) {
							enemyShipX.add((int) (Math.random()*671));
							enemyShipY.add(-50);
							countEnemySpaceships++;
						}else if(num < 6) {
							enemyShip2X.add((int) (Math.random()*671));
							enemyShip2Y.add(-50);
							enemyShip2Health.add(1);
							enemyShip2Hit.add(0);
							countEnemySpaceships2++;
						}else {
							int x = 0; boolean finishee = true;
							while(true) {
								x = (int) (Math.random()*651);
								for(int i = 0; i < countEnemySpaceships3; i++) {
									if(x >= enemyShip3X.get(i)-70 && x <= enemyShip3X.get(i) + 70) {
										finishee = false;
									}
								}
								if(finishee) {
									break;
								}
							}
							enemyShip3X.add(x);
							enemyShip3Y.add(-50);
							enemyShip3Health.add(1);
							enemyShip3Hit.add(0);
							enemyShip3AttackTime.add(0);
							countEnemySpaceships3++;
						}
					}
				}else if(e.getSource() == difficultyTimer && amount <10) {					//increasing difficulty
					amount++;
					time -= 150;
					shipTimer.setDelay(time);
					difficultyTimer.setDelay(difficultyTimer.getDelay()+10000);
					difficultyTimerInitialAmount = difficultyTimer.getDelay();
				}else if(e.getSource() == powerupTimer) {
					byte num = (byte) (Math.random()*4);
					if(num == 0) {
						selectedPowerup = speedPowerup;
					}else if(num == 1) {
						selectedPowerup = fireRatePowerup;
					}else if(num == 2) {
						selectedPowerup = healthPowerup;
					}else {
						selectedPowerup = shieldPowerup;
					}
					while(true) {
						boolean end = true;
						powerupX = (int) (Math.random()*681);
						powerupY = -40;
						for(int i = 0; i < countEnemySpaceships; i++) {
							if(powerupX+40 >= enemyShipX.get(i) && powerupX <= enemyShipX.get(i)+50 && powerupY+40 >= enemyShipY.get(i) && powerupY <= enemyShipY.get(i)+50) {
								end = false;
								break;
							}
						}
						if(end) {
							for(int i = 0; i < countEnemySpaceships2; i++) {
								if(powerupX+40 >= enemyShip2X.get(i) && powerupX <= enemyShip2X.get(i)+50 && powerupY+40 >= enemyShip2Y.get(i) && powerupY <= enemyShip2Y.get(i)+50) {
									end = false;
									break;
								}
							}
						}
						if(end) {
							for(int i = 0; i < countEnemySpaceships3; i++) {
								if(powerupX+40 >= enemyShip3X.get(i) && powerupX <= enemyShip3X.get(i)+70 && powerupY+40 >= enemyShip3Y.get(i) && powerupY <= enemyShip3Y.get(i)+60) {
									end = false;
									break;
								}
							}
						}
						if(end) {
							break;
						}
					}
				}
				if(powerupTime <= 0) {
					fireRate = 750;
					movementSpeed = movementSpeedUpgraded + 3;
				}
				if(powerupTime > 0) {
					powerupTime -= 15;
				}
				if(invulnerableTime > 0) {
					invulnerableTime -= 15;
				}
				timerPauseAmount -= 15;
				difficultyTimerInitialAmount -= 15;
				compareTime -= 15;
				powerupTimeInitialAmount -= 15;
				
				if(halfLives <= 0 && !gameOverMenu) {
					f.addMouseListener(this);
					f.addMouseMotionListener(this);
					gameOverMenu = true;
					t.stop();
					menuTimer.start();
					shipTimer.stop();
					difficultyTimer.stop();
				}
				for(int i = 0; i < countEnemySpaceships3; i++) {
					if(enemyShip3AttackTime.get(i) > 0) {
						int t = enemyShip3AttackTime.get(i) - 15;
						enemyShip3AttackTime.remove(i);
						enemyShip3AttackTime.add(i, t);
					}
				}
				moveSpaceImage();
				enemyShips3Shoot();
				moveEnemy3Plasma();
				checkEnemy3PlasmaCollision();
				movePowerup();
				checkPowerupCollision();
				movePicture();
				createMissile();
				moveMissiles();
				moveEnemySpaceship();	
				checkMissileCollision();
				checkEnemySpaceshipCollision();
				repaint();
			}else if(campaignMode){
				if(e.getSource() == shipTimer && !boss) {
					if(time == 20) {
						time = 2000;
						shipTimer.setDelay(time);
					}else {
						timerPauseAmount = 2000;
						if(level3) {
							System.out.println("making minions");
							int num = (int) (Math.random()*41);
							if(num >= 23) {
								enemyShip3X.add((int) (Math.random()*651));
								enemyShip3Y.add(-50);
								enemyShip3Health.add(1);
								enemyShip3Hit.add(0);
								enemyShip3AttackTime.add(0);
								countEnemySpaceships3++;
							}else if(num >= 10){
								enemyShip2X.add((int) (Math.random()*671));
								enemyShip2Y.add(-50);
								enemyShip2Health.add(1);
								enemyShip2Hit.add(0);
								countEnemySpaceships2++;
							}else {
								enemyShipX.add((int) (Math.random()*671));
								enemyShipY.add(-50);
								countEnemySpaceships++;
							}
						}else if(level2) {
							System.out.println("making minions");
							int num = (int) (Math.random()*21);
							if(num <= 13) {
								enemyShip2X.add((int) (Math.random()*671));
								enemyShip2Y.add(-50);
								enemyShip2Health.add(1);
								enemyShip2Hit.add(0);
								countEnemySpaceships2++;
							}else {
								System.out.println("making minions");
								enemyShipX.add((int) (Math.random()*671));
								enemyShipY.add(-50);
								countEnemySpaceships++;
							}
						}else {
							enemyShipX.add((int) (Math.random()*671));
							enemyShipY.add(-50);
							countEnemySpaceships++;
						}
						//add an if statement here so you'll be able to add different kind of spaceships
					}
				}else if(e.getSource() == bossAbilityTimer && bossHealth != 0) {//rather make a function that will decide randomly --? did, its a smart idea ;)
					bossAbilityTimeInitialAmount = 3000;
					bossAbilityTimer.setDelay(bossAbilityTimeInitialAmount);
					enemyLasersY.clear();enemyLasersX.clear();countEnemyLasers = 0;
					moveDrone0 = false;moveDrone1 = false;moveDrone2 = false;moveDrone3 = false;
					int num = (int) (Math.random()*3);//*3 here
					if(num == 2) {
						if(enemyShipY.isEmpty() && enemyShip2Y.isEmpty() && enemyShip3Y.isEmpty()) {//
							primary = false;
							secondary = false;
							createMinions();
						}else {
							num = (int) (Math.random()*2);
							if(num == 0) {
								if(level2) {
									positions.clear();
									for(int i = 1; i < 9; i++) {
										positions.add(i);
									}
									byte num2 = (byte) (Math.random()*4);
									positions.remove(num2);
									num2 = (byte) (Math.random()*3);
									positions.remove(num2);
									num2 = (byte) (Math.random()*4 + 2);
									positions.remove(num2);
									num2 = (byte) (Math.random()*3 + 2);
									positions.remove(num2);
								}
								primary = true;
								secondary = false;
								firePrimaryWeapon();
							}else {
								byte num3 = (byte) (Math.random()*4);
								if(num3 == 0) {
									moveDrone0 = true; moveDrone1 = true; moveDrone2 = false; moveDrone3 = false;
								}else if(num3 == 1) {
									moveDrone2 = true; moveDrone3 = true; moveDrone0 = false; moveDrone1 = false;
								}else if(num3 == 2) {
									moveDrone0 = true; moveDrone3 = true; moveDrone1 = false; moveDrone2 = false;
								}else {
									moveDrone1 = true; moveDrone2 = true; moveDrone0 = false; moveDrone3 = false;
								}
								secondary = true;
								primary = false;
								fireSecondaryWeapon();
							}
						}
					}else if(num == 0) {//0 here
						//timers don't change their delay immediately if they are still running -> they do one more action with the previous time delay
						secondary = true;
						primary = false;
						byte num3 = (byte) (Math.random()*4);
						if(num3 == 0) {
							moveDrone0 = true;moveDrone1 = true;moveDrone2 = false;moveDrone3 = false;
						}else if(num3 == 1) {
							moveDrone2 = true;moveDrone3 = true;moveDrone0 = false;moveDrone1 = false;
						}else if(num3 == 2) {
							moveDrone0 = true;moveDrone3 = true;moveDrone1 = false;moveDrone2 = false;
						}else {
							moveDrone1 = true;moveDrone2 = true;moveDrone0 = false;moveDrone3 = false;
						}
						fireSecondaryWeapon();
					}else {
						if(level2) {
							positions.clear();
							for(int i = 1; i < 9; i++) {
								positions.add(i);
							}
							byte num2 = (byte) (Math.random()*4);
							positions.remove(num2);
							num2 = (byte) (Math.random()*3);
							positions.remove(num2);
							num2 = (byte) (Math.random()*4 + 2);
							positions.remove(num2);
							num2 = (byte) (Math.random()*3 + 2);
							positions.remove(num2);
						}
						primary = true;
						secondary = false;
						firePrimaryWeapon();
					}
				}else if(e.getSource() == powerupTimer) {
					byte num = (byte) (Math.random()*4);
					if(num == 0) {
						selectedPowerup = speedPowerup;
					}else if(num == 1) {
						selectedPowerup = fireRatePowerup;
					}else if(num == 2) {
						selectedPowerup = healthPowerup;
					}else {
						selectedPowerup = shieldPowerup;
					}
					byte num2 = (byte) (Math.random()*2);
					if(boss && level3) {
						if(num2 == 1) {
							powerupX = (int) (Math.random()*((this.getWidth()-200)/2-8-40))+220+(this.getWidth()-200)/2-8;
						}else {
							powerupX= (int) (Math.random()*((this.getWidth()-200)/2-8-40));
						}
					}else if(boss && level2) {
						if(num2 == 1) {
							powerupX = (int) (Math.random()*((this.getWidth()-230)/2-8-40))+230+(this.getWidth()-230)/2-8;
						}else {
							powerupX = (int) (Math.random()*((this.getWidth()-230)/2-8-40));
						}
					} else if(boss) {
						if(num2 == 1) {
							powerupX = (int) (Math.random()*((this.getWidth()-270)/2-8-40))+270+(this.getWidth()-270)/2-8;
						}else {
							powerupX = (int) (Math.random()*((this.getWidth()-270)/2-8-40));
						}
					}else {
						powerupX = (int) (Math.random()*681);
					}
					powerupY = -40;
				}
				//TIMER t
				if(powerupTime <= 0) {
					fireRate = 750;
					movementSpeed = 3;
				}
				if(powerupTime > 0) {
					powerupTime -= 15;
				}
				timerPauseAmount -= 15;
				compareTime -= 15;
				bossAbilityTimeInitialAmount -= 15;
				powerupTimeInitialAmount -= 15;
				if(invulnerableTime > 0) {
					invulnerableTime -= 15;
				}
				if(boss && secondary && attackTime > 0) {
					attackTime -= 15;
				}
				if(boss && primary && level2 && attackTime > 0) {
					attackTime -= 15;
				}
				if(levelTime > 0 && !boss) {
					levelTime -= 15;
				}
				if(dronesAttackTime > 0) {
					dronesAttackTime -= 15;
				}
				for(int i = 0; i < countEnemySpaceships3; i++) {
					if(enemyShip3AttackTime.get(i) > 0) {
						int t = enemyShip3AttackTime.get(i) - 15;
						enemyShip3AttackTime.remove(i);
						enemyShip3AttackTime.add(i, t);
					}
				}
				if(halfLives <= 0 && !gameOverMenu) {
					f.addMouseListener(this);
					f.addMouseMotionListener(this);
					gameOverMenu = true;
					t.stop();
					shipTimer.stop();
					difficultyTimer.stop();
					bossAbilityTimer.stop();
					menuTimer.start();
				}
				if(levelTime <= 0 && !boss) {
					if(level3) {
						bossHealth = 100;//100 here - might balance it
						bossAbilityTimeInitialAmount = 7050;
						bossY = -220;
					}else if(level2) {
						bossHealth = 75;//75 here - might balance it
						bossY = -230;
						bossAbilityTimeInitialAmount = 7330;
					}else {
						//bossY is already - 140
						bossHealth = 50;// 50 here - might balance it
						bossAbilityTimeInitialAmount = 5100;
					}
					bossHit = 0;
					
					boss = true;
					levelTime = 30000;
					shipTimer.stop();
					
					bossAbilityTimer.setInitialDelay(bossAbilityTimeInitialAmount);
					bossAbilityTimer.start();
				}
				
				if(boss) {
					moveBoss();
					checkBossHit();
					if(boss && !wait && bossHealth == 0 && bossExplode == 0) {
						boss = false;
						primary = false;
						secondary = false;
						bossAbilityTimer.stop();
						for(int i = 0; i < countEnemySpaceships; i++) {
							if(enemyShipY.get(i) < -50) {
								enemyShipX.remove(i);
								enemyShipY.remove(i);
								countEnemySpaceships--;
								i--;
							}
						}
						for(int i = 0; i < countEnemySpaceships2; i++) {
							if(enemyShip2Y.get(i) < -50) {
								enemyShip2X.remove(i);
								enemyShip2Y.remove(i);
								enemyShip2Health.remove(i);
								enemyShip2Hit.remove(i);
								countEnemySpaceships2--;
								i--;
							}
						}
						for(int i = 0; i < countEnemySpaceships3; i++) {
							if(enemyShip3Y.get(i) < -50) {
								enemyShip3X.remove(i);
								enemyShip3Y.remove(i);
								enemyShip3Health.remove(i);
								enemyShip3Hit.remove(i);
								enemyShip3AttackTime.remove(i);
								countEnemySpaceships3--;
								i--;
							}
						}
						shipTimer.setInitialDelay(1695);
						shipTimer.setDelay(3000);//maybe change permanently to 3s? idk i think so
						shipTimer.start();
						if(level2) {
							level3 = true;
							level2 = false;
						}else if(!level3){
							level2 = true;
						}else {
							level3 = false;
							winMenu = true;
						}
					}
				}
				if(level3){
					enemyShips3Shoot();
					moveEnemy3Plasma();
					checkEnemy3PlasmaCollision();
					
					moveEnemyPlasmaBullets();
					checkEnemyPlasmaBulletsCollision();
					if(secondary) {
						dronesShoot();
					}
					moveEnemyDrones();
					moveDroneBullets();
					checkDroneBulletsCollision();
				}else if(level2){
					if(!enemyBulletsX.isEmpty() || !enemyMissilesX.isEmpty()) {
						moveEnemyMissiles();
						moveEnemyBullets();
						checkEnemyMissilesCollision();
						checkEnemyBulletsCollision();
					}
					//functions for primary fire
					if(primary) {
						createEnemyLasers();//IMPORTANT - MAKE IT SO YOU DO ONE EVERY few more MS NOT EVERY 15MS - GONNA EAT LESS MEMORY
					}
					moveEnemyLasers();
					checkEnemyLasersCollision();
					if(countEnemyBullets2 > 6 && explosionsBullets2X.isEmpty()) {
						explosionsBullets2X.add(enemyBullets2X.get(0));
						explosionsBullets2Y.add(enemyBullets2Y.get(0));
						enemyBullets2howManyRepaints.add(10);
						enemyBullets2X.remove(0);
						enemyBullets2Y.remove(0);
						delta2X.remove(0);
						delta2Y.remove(0);
						accelaration.remove(0);
						countEnemyBullets2--;
						countBullets2Explosions++;
					}else if(boss && bossHealth == 0 && explosionsBullets2X.isEmpty() && countEnemyBullets2 > 0) {//removing mines when boss2 is defeated
						explosionsBullets2X.add(enemyBullets2X.get(0));
						explosionsBullets2Y.add(enemyBullets2Y.get(0));
						enemyBullets2howManyRepaints.add(10);
						enemyBullets2X.remove(0);
						enemyBullets2Y.remove(0);
						delta2X.remove(0);
						delta2Y.remove(0);
						accelaration.remove(0);
						countEnemyBullets2--;
						countBullets2Explosions++;
					}
					moveEnemyBullets2();
					checkEnemyBullets2MissileCollision();
					checkEnemyBullets2Collision();
				}else {
					moveEnemyMissiles();
					if(attackTime <= 0 && secondary) {
						createEnemyBullet();
						attackTime = 300;
					}
					moveEnemyBullets();
					checkEnemyMissilesCollision();
					checkEnemyBulletsCollision();
				}
				moveSpaceImage();
				movePowerup();
				checkPowerupCollision();
				movePicture();
				createMissile();
				moveMissiles();
				moveEnemySpaceship();
				repaint();
				checkMissileCollision();
				checkEnemySpaceshipCollision();
			}
		}
		repaint();
	}
	
	
	@Override
	public void mouseClicked(MouseEvent arg0) {}
	@Override
	public void mouseEntered(MouseEvent arg0) {}
	@Override
	public void mouseExited(MouseEvent arg0) {}
	@Override
	public void mousePressed(MouseEvent arg0) {}
	
	
	@Override
	public void mouseReleased(MouseEvent e) {
		if(helpMenu) {
			if(mouseMovedX >= 8 && mouseMovedX <= 130+8 && mouseMovedY >= 5+31 && mouseMovedY <= 45+31) {
				helpMenu = false;
			}
		}else if(controlsMenu) {
			if(mouseMovedX >= 8 && mouseMovedX <= 130+8 && mouseMovedY >= 5+31 && mouseMovedY <= 45+31) {
				controlsMenu = false;
			}
		}else if(optionsMenu) {
			if(mouseMovedX >= (f.getWidth()-313)/2 && mouseMovedX <= (f.getWidth()-313)/2+313 && mouseMovedY >= 25+31 && mouseMovedY <= 120+31) {
				helpMenu = true;
			}else if (mouseMovedX >= (f.getWidth()-633)/2 && mouseMovedX <= (f.getWidth()-633)/2+633 && mouseMovedY >= 150+31 && mouseMovedY <= 245+31) {
				controlsMenu = true;
			}else if (mouseMovedX >= (f.getWidth()-322)/2 && mouseMovedX <= (f.getWidth()-322)/2+322 && mouseMovedY >= 270+31 && mouseMovedY <= 365+31) {
				optionsMenu = false;
			}
		}else if(upgradeMenu) {
			if(mouseMovedX >= 8 && mouseMovedX <= 145+8 && mouseMovedY >= 5+31 && mouseMovedY <= 37+31) {
				f.removeMouseListener(this);
				f.removeMouseMotionListener(this);
				upgradeMenu = false;
				menuTimer.stop();
				t.start();
				if(timerPauseAmount > 0) {
					shipTimer.setInitialDelay(timerPauseAmount);
				}
				if(difficultyTimerInitialAmount > 0) {
					difficultyTimer.setInitialDelay(difficultyTimerInitialAmount);
				}
				difficultyTimer.start();
				shipTimer.start();
			}else if((mouseMovedX >= 280+8 && mouseMovedX <= 280+7+70 && mouseMovedY >= 32+5+28 && mouseMovedY <= 40+70+23) && healthUpgraded < 5 && healthUpgradeCost <= score) {//TUKI DODEJ DA MORŠ MET DOVOLJ SCORE DA LAH NARDIŠ TO
				halfLives += 6; score -= healthUpgradeCost; healthUpgradeCost += healthUpgradeCost/2;
				healthUpgraded++;
			}else if((mouseMovedX >= 305+8 && mouseMovedX <= 305+7+70 && mouseMovedY >= 117+5+28 && mouseMovedY <= 115+70+23) && fireRateUpgraded < 5 && fireRateUpgradeCost <= score){
				fireRate -= 110; score -= fireRateUpgradeCost; fireRateUpgradeCost += fireRateUpgradeCost/2;
				fireRateUpgraded++;
			}else if((mouseMovedX >= 400+8 && mouseMovedX <= 400+7+70 && mouseMovedY >= 182+5+28 && mouseMovedY <= 182+70+28) && movementSpeedUpgraded < 3 && movementSpeedUpgradeCost <= score) {
				movementSpeed++; score -= movementSpeedUpgradeCost; movementSpeedUpgradeCost += movementSpeedUpgradeCost/2;
				movementSpeedUpgraded++;
			}else if((mouseMovedX >= 375+8 && mouseMovedX <= 375+7+70 && mouseMovedY >= 257+5+28 && mouseMovedY <= 257+70+28) && !hullReinforced && hullReinforcementCost <= score) {
				hullReinforced = true; score -= hullReinforcementCost;
			}else if((mouseMovedX >= 330+8 && mouseMovedX <= 330+7+70 && mouseMovedY >= 332+5+28 && mouseMovedY <= 332+70+28) && !reducedEnemyDamage && reduceEnemyDamageCost <= score) {
				reducedEnemyDamage = true; score -= reduceEnemyDamageCost;
			}
		}else if(gameModeSelectionMenu) {
			if(mouseMovedX >= (f.getWidth()-640)/2 && mouseMovedX <= (f.getWidth()-640)/2+640 && mouseMovedY >= 25+31 && mouseMovedY <= 120+31) {
				gameModeSelectionMenu = false;
				mainMenu = true;
				campaignMode = true;
			}else if (mouseMovedX >= (f.getWidth()-577)/2 && mouseMovedX <= (f.getWidth()-577)/2+577 && mouseMovedY >= 150+31 && mouseMovedY <= 245+31) {
				gameModeSelectionMenu = false;
				mainMenu = true;
				survivalMode = true;
			}else if (mouseMovedX >= (f.getWidth()-245)/2 && mouseMovedX <= (f.getWidth()-245)/2+245 && mouseMovedY >= 270+31 && mouseMovedY <= 365+31) {
				System.exit(0);
			}
		}else if(mainMenu) {
			if(mouseMovedX >= (f.getWidth()-310)/2 && mouseMovedX <= (f.getWidth()-310)/2+310 && mouseMovedY >= 25+31 && mouseMovedY <= 120+31) {
				f.removeMouseListener(this);
				f.removeMouseMotionListener(this);
				mainMenu = false;
				menuTimer.stop();
				t.start();
				shipTimer.start();
				difficultyTimer.start();
				powerupTimer.setInitialDelay(20000);
				powerupTimer.start();
			}else if (mouseMovedX >= (f.getWidth()-520)/2 && mouseMovedX <= (f.getWidth()-520)/2+520 && mouseMovedY >= 150+31 && mouseMovedY <= 245+31) {
				optionsMenu = true;
			}else if (mouseMovedX >= (f.getWidth()-245)/2 && mouseMovedX <= (f.getWidth()-245)/2+245 && mouseMovedY >= 270+31 && mouseMovedY <= 365+31) {
				mainMenu = false;
				survivalMode = false;
				campaignMode = false;
				gameModeSelectionMenu = true;
			}
		}else if(pauseMenu) {
			if(mouseMovedX >= (f.getWidth()-463)/2 && mouseMovedX <= (f.getWidth()-463)/2+463 && mouseMovedY >= 25+31 && mouseMovedY <= 120+31) {
				f.removeMouseListener(this);
				f.removeMouseMotionListener(this);
				pauseMenu = false;
				menuTimer.stop();
				t.start();
				if(timerPauseAmount > 0) {
					shipTimer.setInitialDelay(timerPauseAmount);
				}
				if(difficultyTimerInitialAmount > 0) {
					difficultyTimer.setInitialDelay(difficultyTimerInitialAmount);
				}
				if(bossAbilityTimeInitialAmount> 0) {
					bossAbilityTimer.setInitialDelay(bossAbilityTimeInitialAmount);
				}
				if(powerupTimeInitialAmount> 0) {
					powerupTimer.setInitialDelay(powerupTimeInitialAmount);
				}
				powerupTimer.start();
				bossAbilityTimer.start();
				difficultyTimer.start();
				shipTimer.start();
			}else if (mouseMovedX >= (f.getWidth()-313)/2 && mouseMovedX <= (f.getWidth()-313)/2+313 && mouseMovedY >= 150+31 && mouseMovedY <= 245+31) {
				optionsMenu = true;
			}else if (mouseMovedX >= (f.getWidth()-693)/2 && mouseMovedX <= (f.getWidth()-693)/2+693 && mouseMovedY >= 270+31 && mouseMovedY <= 365+31) {
				//nared meteod da bo pokiica k bom nucu tut pr PLAY AGAIN -- ne n ucm se mi zdi
				//IMPORTANT - ADD ALL THE ORIGINAL VALUES THAT YOU AHVE ADDED
				compareTime = 0;
				countMissiles = 0;
				countEnemySpaceships = 0;
				countExplosions = 0;
				countEnemyMissiles = 0;
				countEnemyBullets = 0;
				countEnemySpaceships2 = 0;
				countEnemyBullets2 = 0;
				countEnemyBullets2Explosions = 0;
				countBullets2Explosions = 0;
				countEnemyLasers = 0;
				countExplosionsBoss = 0;
				countEnemySpaceships3 = 0;
				countEnemyPlasma = 0;
				countEnemyPlasmaBullets = 0;
				countEnemyDroneBullets = 0;
				countEnemyDroneBullets2 = 0;
				
				halfLives = 10;
				fireRate = 750;
				movementSpeed = 3;
				healthUpgraded = 0;
				movementSpeedUpgraded = 0;
				fireRateUpgraded = 0;
				healthUpgradeCost = 800;
				fireRateUpgradeCost = 800;
				movementSpeedUpgradeCost = 1000;
				hullReinforcementCost = 4000;
				reduceEnemyDamageCost = 4000;
				
				up = false;
				down = false;
				left = false;
				right = false;
				spacebar = false;
				upgradeMenu = false;
				gameOverMenu = false;
				
				mainMenu = true;
				pauseMenu = false;
				hullReinforced = false;
				reducedEnemyDamage = false;
				level2 = false;
				level3 = false;
				boss = false;
				wait = false;
				primary = false;
				secondary = false;
				
				powerupX = 0;
				powerupY = 500;
				powerupTime = 0;
				shields = 0;
				
				score = 0;
				spaceX = 300;
				spaceY = 230;
				time = 20;
				difficultyTimerInitialAmount = 20000;
				timerPauseAmount = 0;
				levelTime = 30000;//have to balance it
				bossAbilityTimeInitialAmount = 5100;//balance as well
				attackTime = 0;
				invulnerableTime = 0;
				
				enemySpeed = 1;
				mouseMovedX = 0;
				mouseMovedY = 0;
				bossHit = 0;
				bossExplode = 0;
				bossY = -160;
				yourShipHit = 0;
				
				ex = -100;
				ey = -100;
				
				missilesX.clear();
				missilesY.clear();
				
				//ship type
				enemyType.clear();
				//ships type1
				
				enemyShipX.clear();
				enemyShipY.clear();
				
				//ships type2
				enemyShip2X.clear();
				enemyShip2Y.clear();
				enemyShip2Health.clear();
				enemyShip2Hit.clear();
				
				//ships type3
				enemyShip3X.clear();
				enemyShip3Y.clear();
				enemyShip3Health.clear();
				enemyShip3Hit.clear();
				enemyShip3AttackTime.clear();
				enemyPlasmaX.clear();
				enemyPlasmaY.clear();
				
				//explosions
				explosionsX.clear();
				explosionsY.clear();
				howManyRepaints.clear();
				
				//boss exposions
				howManyRepaintsBoss.clear();
				explosionsBossX.clear();
				explosionsBossY.clear();
				
				//boss1
				enemyMissilesX.clear();
				enemyMissilesY.clear();
				
				enemyBulletsX.clear();
				enemyBulletsY.clear();
				deltaMoveX.clear();
				deltaMoveY.clear();
				
				//boss2
				enemyLasersX.clear();
				enemyLasersY.clear();
				positions.clear();
			
				enemyBullets2X.clear();
				enemyBullets2Y.clear();
				delta2X.clear();
				delta2Y.clear();
				accelaration.clear();
				enemyBullets2howManyRepaints.clear();
				explosionsBullets2X.clear();
				explosionsBullets2Y.clear();
				
				//boss3 primary fire
				enemyPlasmaBulletsX.clear();
				enemyPlasmaBulletsY.clear();
				deltaMovePlasmaBulletsX.clear();
				deltaMovePlasmaBulletsY.clear();
				
				//boss3 secondary fire
				dronesX.clear();
				dronesY.clear();
				droneBulletsX.clear();
				droneBulletsY.clear();
				droneBullets2X.clear();
				droneBullets2Y.clear();
				dronesX.add(-30);
				dronesY.add(240);
				dronesX.add(-30);
				dronesY.add(385);
				dronesX.add(750);
				dronesY.add(240);
				dronesX.add(750);
				dronesY.add(385);
				
				//timers
				shipTimer.setDelay(time);
				shipTimer.setInitialDelay(40);
				difficultyTimer.setDelay(20000);
				difficultyTimer.setInitialDelay(20000);
				bossAbilityTimer.setInitialDelay(bossAbilityTimeInitialAmount);
				powerupTimer.setInitialDelay(20000);
			}
		}else if(gameOverMenu) {
			if(mouseMovedX >= (f.getWidth()-375)/2 && mouseMovedX <= (f.getWidth()-375)/2+375 && mouseMovedY >= 25+31 && mouseMovedY <= 120+31) {
				f.removeMouseListener(this);
				f.removeMouseMotionListener(this);
				
				compareTime = 0;
				countMissiles = 0;
				countEnemySpaceships = 0;
				countExplosions = 0;
				countEnemyMissiles = 0;
				countEnemyBullets = 0;
				countEnemySpaceships2 = 0;
				countEnemyBullets2 = 0;
				countEnemyBullets2Explosions = 0;
				countBullets2Explosions = 0;
				countEnemyLasers = 0;
				countExplosionsBoss = 0;
				countEnemySpaceships3 = 0;
				countEnemyPlasma = 0;
				countEnemyPlasmaBullets = 0;
				countEnemyDroneBullets = 0;
				countEnemyDroneBullets2 = 0;
				
				halfLives = 10;
				fireRate = 750;
				movementSpeed = 3;
				healthUpgraded = 0;
				movementSpeedUpgraded = 0;
				fireRateUpgraded = 0;
				healthUpgradeCost = 800;
				fireRateUpgradeCost = 800;
				movementSpeedUpgradeCost = 1000;
				hullReinforcementCost = 4000;
				reduceEnemyDamageCost = 4000;
				
				up = false;
				down = false;
				left = false;
				right = false;
				spacebar = false;
				upgradeMenu = false;
				gameOverMenu = false;
				pauseMenu = false;
				hullReinforced = false;
				reducedEnemyDamage = false;
				level2 = false;
				level3 = false;
				boss = false;
				wait = false;
				primary = false;
				secondary = false;
				
				powerupX = 0;
				powerupY = 500;
				powerupTime = 0;
				shields = 0;
				
				score = 0;
				spaceX = 300;
				spaceY = 230;
				time = 20;
				difficultyTimerInitialAmount = 20000;
				timerPauseAmount = 0;
				levelTime = 30000;//have to balance it
				bossAbilityTimeInitialAmount = 5100;//balance as well
				attackTime = 0;
				invulnerableTime = 0;
				
				enemySpeed = 1;
				mouseMovedX = 0;
				mouseMovedY = 0;
				bossHit = 0;
				bossExplode = 0;
				bossY = -160;
				yourShipHit = 0;
				
				ex = -100;
				ey = -100;
				
				missilesX.clear();
				missilesY.clear();
				
				//ship type
				enemyType.clear();
				//ships type1
				
				enemyShipX.clear();
				enemyShipY.clear();
				
				//ships type2
				enemyShip2X.clear();
				enemyShip2Y.clear();
				enemyShip2Health.clear();
				enemyShip2Hit.clear();
				
				//ships type3
				enemyShip3X.clear();
				enemyShip3Y.clear();
				enemyShip3Health.clear();
				enemyShip3Hit.clear();
				enemyShip3AttackTime.clear();
				enemyPlasmaX.clear();
				enemyPlasmaY.clear();
				
				//explosions
				explosionsX.clear();
				explosionsY.clear();
				howManyRepaints.clear();
				
				//boss exposions
				howManyRepaintsBoss.clear();
				explosionsBossX.clear();
				explosionsBossY.clear();
				
				//boss1
				enemyMissilesX.clear();
				enemyMissilesY.clear();
				
				enemyBulletsX.clear();
				enemyBulletsY.clear();
				deltaMoveX.clear();
				deltaMoveY.clear();
				
				//boss2
				enemyLasersX.clear();
				enemyLasersY.clear();
				positions.clear();
			
				enemyBullets2X.clear();
				enemyBullets2Y.clear();
				delta2X.clear();
				delta2Y.clear();
				accelaration.clear();
				enemyBullets2howManyRepaints.clear();
				explosionsBullets2X.clear();
				explosionsBullets2Y.clear();
				
				//boss3 primary fire
				enemyPlasmaBulletsX.clear();
				enemyPlasmaBulletsY.clear();
				deltaMovePlasmaBulletsX.clear();
				deltaMovePlasmaBulletsY.clear();
				
				//boss3 secondary fire
				dronesX.clear();
				dronesY.clear();
				droneBulletsX.clear();
				droneBulletsY.clear();
				droneBullets2X.clear();
				droneBullets2Y.clear();
				dronesX.add(-30);
				dronesY.add(240);
				dronesX.add(-30);
				dronesY.add(385);
				dronesX.add(750);
				dronesY.add(240);
				dronesX.add(750);
				dronesY.add(385);
				
				//timers
				shipTimer.setDelay(time);
				shipTimer.setInitialDelay(40);
				difficultyTimer.setDelay(20000);
				difficultyTimer.setInitialDelay(20000);
				bossAbilityTimer.setInitialDelay(bossAbilityTimeInitialAmount);
				powerupTimer.setInitialDelay(20000);
				menuTimer.stop();
				t.start();
				shipTimer.start();
				powerupTimer.start();
				if(survivalMode) {								//do a cleaner difficulty for survivalMode
					difficultyTimer.start();
				}
			}else if(mouseMovedX >= (f.getWidth()-520)/2 && mouseMovedX <= (f.getWidth()-520)/2+520 && mouseMovedY >= 150+31 && mouseMovedY <= 245+31) {
				optionsMenu = true;
			}else if(mouseMovedX >= (f.getWidth()-693)/2 && mouseMovedX <= (f.getWidth()-693)/2+693 && mouseMovedY >= 270+31 && mouseMovedY <= 365+31) {
				compareTime = 0;
				countMissiles = 0;
				countEnemySpaceships = 0;
				countExplosions = 0;
				countEnemyMissiles = 0;
				countEnemyBullets = 0;
				countEnemySpaceships2 = 0;
				countEnemyBullets2 = 0;
				countEnemyBullets2Explosions = 0;
				countBullets2Explosions = 0;
				countEnemyLasers = 0;
				countExplosionsBoss = 0;
				countEnemySpaceships3 = 0;
				countEnemyPlasma = 0;
				countEnemyPlasmaBullets = 0;
				countEnemyDroneBullets = 0;
				countEnemyDroneBullets2 = 0;
				
				halfLives = 10;
				fireRate = 750;
				movementSpeed = 3;
				healthUpgraded = 0;
				movementSpeedUpgraded = 0;
				fireRateUpgraded = 0;
				healthUpgradeCost = 800;
				fireRateUpgradeCost = 800;
				movementSpeedUpgradeCost = 1000;
				hullReinforcementCost = 4000;
				reduceEnemyDamageCost = 4000;
				
				up = false;
				down = false;
				left = false;
				right = false;
				spacebar = false;
				upgradeMenu = false;
				gameOverMenu = false;
				mainMenu = true;
				pauseMenu = false;
				hullReinforced = false;
				reducedEnemyDamage = false;
				level2 = false;
				level3 = false;
				boss = false;
				wait = false;
				primary = false;
				secondary = false;
				
				powerupX = 0;
				powerupY = 500;
				powerupTime = 0;
				shields = 0;
				
				score = 0;
				spaceX = 300;
				spaceY = 230;
				time = 20;
				difficultyTimerInitialAmount = 20000;
				timerPauseAmount = 0;
				levelTime = 30000;//have to balance it
				bossAbilityTimeInitialAmount = 5100;//balance as well
				attackTime = 0;
				invulnerableTime = 0;
				
				enemySpeed = 1;
				mouseMovedX = 0;
				mouseMovedY = 0;
				bossHit = 0;
				bossExplode = 0;
				bossY = -160;
				yourShipHit = 0;
				
				ex = -100;
				ey = -100;
				
				missilesX.clear();
				missilesY.clear();
				
				//ship type
				enemyType.clear();
				//ships type1
				
				enemyShipX.clear();
				enemyShipY.clear();
				
				//ships type2
				enemyShip2X.clear();
				enemyShip2Y.clear();
				enemyShip2Health.clear();
				enemyShip2Hit.clear();
				
				//ships type3
				enemyShip3X.clear();
				enemyShip3Y.clear();
				enemyShip3Health.clear();
				enemyShip3Hit.clear();
				enemyShip3AttackTime.clear();
				enemyPlasmaX.clear();
				enemyPlasmaY.clear();
				
				//explosions
				explosionsX.clear();
				explosionsY.clear();
				howManyRepaints.clear();
				
				//boss exposions
				howManyRepaintsBoss.clear();
				explosionsBossX.clear();
				explosionsBossY.clear();
				
				//boss1
				enemyMissilesX.clear();
				enemyMissilesY.clear();
				
				enemyBulletsX.clear();
				enemyBulletsY.clear();
				deltaMoveX.clear();
				deltaMoveY.clear();
				
				//boss2
				enemyLasersX.clear();
				enemyLasersY.clear();
				positions.clear();
			
				enemyBullets2X.clear();
				enemyBullets2Y.clear();
				delta2X.clear();
				delta2Y.clear();
				accelaration.clear();
				enemyBullets2howManyRepaints.clear();
				explosionsBullets2X.clear();
				explosionsBullets2Y.clear();
				
				//boss3 primary fire
				enemyPlasmaBulletsX.clear();
				enemyPlasmaBulletsY.clear();
				deltaMovePlasmaBulletsX.clear();
				deltaMovePlasmaBulletsY.clear();
				
				//boss3 secondary fire
				dronesX.clear();
				dronesY.clear();
				droneBulletsX.clear();
				droneBulletsY.clear();
				droneBullets2X.clear();
				droneBullets2Y.clear();
				dronesX.add(-30);
				dronesY.add(240);
				dronesX.add(-30);
				dronesY.add(385);
				dronesX.add(750);
				dronesY.add(240);
				dronesX.add(750);
				dronesY.add(385);
				
				//timers
				shipTimer.setDelay(time);
				shipTimer.setInitialDelay(40);
				difficultyTimer.setDelay(20000);
				difficultyTimer.setInitialDelay(20000);
				bossAbilityTimer.setInitialDelay(bossAbilityTimeInitialAmount);
				powerupTimer.setInitialDelay(20000);
			}
		}else if(winMenu) {
			
		}
	}
	@Override
	public void mouseDragged(MouseEvent arg0) {}
	@Override
	
	public void mouseMoved(MouseEvent e) {
		mouseMovedX = e.getX();
		mouseMovedY = e.getY();
	}	
}
USE [master]
GO
/****** Object:  Database [EsemkaHero]    Script Date: 29/12/2023 07:49:28 ******/
CREATE DATABASE [EsemkaHero]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EsemkaHero', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EsemkaHero.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EsemkaHero_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EsemkaHero_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EsemkaHero] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EsemkaHero].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EsemkaHero] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EsemkaHero] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EsemkaHero] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EsemkaHero] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EsemkaHero] SET ARITHABORT OFF 
GO
ALTER DATABASE [EsemkaHero] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EsemkaHero] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EsemkaHero] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EsemkaHero] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EsemkaHero] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EsemkaHero] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EsemkaHero] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EsemkaHero] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EsemkaHero] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EsemkaHero] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EsemkaHero] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EsemkaHero] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EsemkaHero] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EsemkaHero] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EsemkaHero] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EsemkaHero] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EsemkaHero] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EsemkaHero] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EsemkaHero] SET  MULTI_USER 
GO
ALTER DATABASE [EsemkaHero] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EsemkaHero] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EsemkaHero] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EsemkaHero] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EsemkaHero] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EsemkaHero] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EsemkaHero] SET QUERY_STORE = OFF
GO
USE [EsemkaHero]
GO
/****** Object:  Table [dbo].[Clan]    Script Date: 29/12/2023 07:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_Clan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Element]    Script Date: 29/12/2023 07:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Element](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Element] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Element] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FightHistory]    Script Date: 29/12/2023 07:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FightHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Hero1ID] [int] NOT NULL,
	[Hero2ID] [int] NOT NULL,
	[Hero1TotalPower] [float] NOT NULL,
	[Hero2TotalPower] [float] NOT NULL,
	[FightDate] [datetime] NOT NULL,
 CONSTRAINT [PK_FightHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hero]    Script Date: 29/12/2023 07:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hero](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [text] NULL,
	[BirthDate] [date] NOT NULL,
	[ClanID] [int] NULL,
 CONSTRAINT [PK_Hero] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HeroSkill]    Script Date: 29/12/2023 07:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeroSkill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HeroID] [int] NOT NULL,
	[SkillID] [int] NOT NULL,
	[Power] [float] NOT NULL,
 CONSTRAINT [PK_HeroSkill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 29/12/2023 07:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [text] NULL,
	[ElementID] [int] NULL,
	[DifficultyLevel] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clan] ON 

INSERT [dbo].[Clan] ([ID], [Name], [Description]) VALUES (2, N'Chinese', N'Surname threads bind generations, weaving tapestries of loyalty. Ancestral halls hum with rituals, echoing triumphs, mourning losses. Clan halls, fortresses of tradition, nurture filial piety, education, shared values. Though tides of history shift, blood whispers unity, clans, whispers of China''s soul.')
INSERT [dbo].[Clan] ([ID], [Name], [Description]) VALUES (3, N'Javanese', N'Suku Jawa memiliki kekuatan "Ilmu Kanuragan" yang memungkinkan mereka menguasai energi dalam pertarungan. Jurus khas termasuk "Gelora Wicara" untuk mengendalikan pikiran lawan dan "Pamungkas Selaras" untuk harmoni alam.')
INSERT [dbo].[Clan] ([ID], [Name], [Description]) VALUES (4, N'Arabic', N'Klan Arab memiliki kekuatan "Ruh Al-Mizaj" yang memanfaatkan energi spiritual. Jurus mereka termasuk "Nur Al-Aql" untuk cahaya pemahaman dan "Hima Al-Hikma" untuk perlindungan ilmu pengetahuan.')
INSERT [dbo].[Clan] ([ID], [Name], [Description]) VALUES (5, N'Madurese', N'Suku Madura dianugerahi kekuatan "Pancaloka" yang menghubungkan mereka dengan lima elemen. Jurus melibatkan "Angin Bayu" untuk kecepatan dan "Api Lembayung" untuk kekuatan meriam. Selain itu mereka juga pengendali elemen besi dan menguasai teknik berdagang tingkat tinggi.')
INSERT [dbo].[Clan] ([ID], [Name], [Description]) VALUES (6, N'Momochi', N'Klan Momochi dikenal karena kemampuan ninja dan keterampilan pedang mereka. Salah satu anggota terkenal adalah Zabuza Momochi, ahli pedang handal dengan jurus "Suiro no Jutsu" yang menciptakan tekanan air mematikan.')
SET IDENTITY_INSERT [dbo].[Clan] OFF
GO
SET IDENTITY_INSERT [dbo].[Element] ON 

INSERT [dbo].[Element] ([ID], [Element]) VALUES (1, N'Air')
INSERT [dbo].[Element] ([ID], [Element]) VALUES (2, N'Angin')
INSERT [dbo].[Element] ([ID], [Element]) VALUES (3, N'Api')
INSERT [dbo].[Element] ([ID], [Element]) VALUES (4, N'Tanah')
INSERT [dbo].[Element] ([ID], [Element]) VALUES (5, N'Kayu')
INSERT [dbo].[Element] ([ID], [Element]) VALUES (6, N'Besi')
INSERT [dbo].[Element] ([ID], [Element]) VALUES (7, N'Cahaya')
INSERT [dbo].[Element] ([ID], [Element]) VALUES (8, N'Uang')
SET IDENTITY_INSERT [dbo].[Element] OFF
GO
SET IDENTITY_INSERT [dbo].[FightHistory] ON 

INSERT [dbo].[FightHistory] ([ID], [Hero1ID], [Hero2ID], [Hero1TotalPower], [Hero2TotalPower], [FightDate]) VALUES (1, 1, 2, 10, 250000, CAST(N'2012-01-08T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[FightHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[Hero] ON 

INSERT [dbo].[Hero] ([ID], [Name], [Description], [BirthDate], [ClanID]) VALUES (1, N'Monica Rambeau', N'Dia dapat mengubah dirinya menjadi segala bentuk energi dalam spektrum elektromagnetik. Di antara banyak bentuk energi yang dia ambil dan mampu kendalikan adalah cahaya tampak, sinar kosmik, sinar gamma, sinar X, radiasi ultraviolet, listrik, radiasi infra merah, gelombang mikro, gelombang radio, dan neutrino.', CAST(N'1998-01-01' AS Date), 2)
INSERT [dbo].[Hero] ([ID], [Name], [Description], [BirthDate], [ClanID]) VALUES (2, N'Jirobo', N'Jirobo biasanya merupakan anggota yang paling tenang, bijaksana, dan pendiam, seperti yang ditunjukkan oleh sikapnya yang kaku. Dia sopan kepada rekan satu timnya', CAST(N'1990-06-06' AS Date), NULL)
INSERT [dbo].[Hero] ([ID], [Name], [Description], [BirthDate], [ClanID]) VALUES (4, N'Raden Wijaya', N'Raden Wijaya atau Dyah Wijaya adalah pendiri dan raja pertama Kerajaan Majapahit yang memerintah pada tahun 1293-1309, bergelar Sri Kertarajasa Jayawardana, atau lengkapnya Nararya Sanggramawijaya Sri Maharaja Kertarajasa Jayawardhana', CAST(N'1970-01-01' AS Date), 3)
INSERT [dbo].[Hero] ([ID], [Name], [Description], [BirthDate], [ClanID]) VALUES (5, N'Prof. Dr. H. Mohammad M. Mahmodin, S.H., S.U, M.I.P.', N'Guru Besar Hukum Tata Negara. Pernah bertugas sbg Menhan, Anggota DPR, dan Ketua MK. Kini mengabdi sbg Menko Polhukam.', CAST(N'1957-05-13' AS Date), 5)
INSERT [dbo].[Hero] ([ID], [Name], [Description], [BirthDate], [ClanID]) VALUES (6, N'Yao Ming', N'Yao Ming, adalah mantan pemain bola basket asal Tiongkok pertama yang bermain di kompetisi NBA. Sejak pertama kali masuk NBA pada tahun 2002 hingga pensiun, dia bermain di klub Houston Rockets', CAST(N'1980-09-12' AS Date), 2)
INSERT [dbo].[Hero] ([ID], [Name], [Description], [BirthDate], [ClanID]) VALUES (7, N'Zabuza Momochi', N'Zabuza pernah dipandang sebagai orang yang karismatik dan inspiratif seperti yang dia impikan sebelumnya tentang sebuah masyarakat; sebuah mimpi yang memotivasi upaya kudeta terhadap Pemimpin Keempat yang tidak dia setujui.', CAST(N'1970-08-15' AS Date), 6)
INSERT [dbo].[Hero] ([ID], [Name], [Description], [BirthDate], [ClanID]) VALUES (8, N'Nasser Al-Khelaifi', N'Nasser bin Ghanim Al-Khelaifi adalah seorang pengusaha Qatar, eksekutif olahraga, dan mantan pemain tenis. Dia adalah ketua beIN Media Group dan Qatar Sports Investments, presiden Paris Saint-Germain F.C., Al Bino F.C. dan Federasi Tenis Qatar, dan wakil presiden Federasi Tenis Asia untuk Asia Barat.', CAST(N'1973-09-12' AS Date), 4)
SET IDENTITY_INSERT [dbo].[Hero] OFF
GO
SET IDENTITY_INSERT [dbo].[HeroSkill] ON 

INSERT [dbo].[HeroSkill] ([ID], [HeroID], [SkillID], [Power]) VALUES (1, 1, 2, 150000)
INSERT [dbo].[HeroSkill] ([ID], [HeroID], [SkillID], [Power]) VALUES (2, 2, 4, 4000)
SET IDENTITY_INSERT [dbo].[HeroSkill] OFF
GO
SET IDENTITY_INSERT [dbo].[Skill] ON 

INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (2, N'Water Release', N'Jutsu Elemen Air paling mudah dilakukan dengan menggunakan sumber air yang ada, seperti danau atau sungai.', 1, N'Easy')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (3, N'Ice Beam', N'Jurus ini menciptakan sinar es yang dapat membekukan musuh.', 1, N'Easy')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (4, N'Water Whip', N'Jurus ini menciptakan cambuk air yang dapat melilit musuh.', 1, N'Easy')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (5, N'Water Clone', N'Jurus ini menciptakan tiruan air dari penggunanya.', 1, N'Medium')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (6, N'Amaterasu', N'Amaterasu dapat dengan mudah mengalahkan api biasa dan tidak mungkin memadamkan apinya. Api hitam Amaterasu tidak berhenti menyala sampai targetnya terbakar seluruhnya. Oleh karena itu, nyala api hanya dapat dihentikan oleh penggunanya.', 3, N'Hard')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (7, N'Fire Wall', N'Jurus ini menciptakan dinding api yang dapat menghalangi musuh.', 3, N'Medium')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (8, N'Fire Dragon', N'Jurus ini menciptakan naga api yang dapat menyerang musuh.', 3, N'Supreme')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (9, N'Fire Storm', N'Jurus ini menciptakan badai api yang dapat menghanguskan musuh.', 3, N'Hard')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (10, N'Wind Blade', N'Jurus ini menciptakan pedang angin yang dapat menebas musuh.', 2, N'Medium')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (11, N'Wind Tornado', N'Jurus ini menciptakan tornado angin yang dapat mengangkat musuh.', 2, N'Hard')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (12, N'Wind Flight', N'Jurus ini dapat membuat penggunanya terbang dengan menggunakan angin.', 2, N'Easy')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (13, N'Earth Quake', N'Jurus ini menciptakan gempa bumi yang dapat mengguncang musuh.', 4, N'Medium')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (14, N'Earth Golem', N'Jurus ini menciptakan golem tanah yang dapat menyerang musuh.', 4, N'Hard')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (15, N'Earth Armor', N'Jurus ini dapat menciptakan baju besi tanah yang dapat melindungi penggunanya.', 4, N'Hard')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (16, N'Lightning Bolt', N'Jurus ini menciptakan petir yang dapat menyambar musuh.', 7, N'Hard')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (17, N'Lightning Storm', N'Jurus ini menciptakan badai petir yang dapat menghantam musuh.', 7, N'Hard')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (18, N'Lightning Shield', N'Jurus ini menciptakan perisai petir yang dapat melindungi penggunanya.', 7, N'Hard')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (19, N'Chidori', N'Saluran teknik ini ada pada sejumlah besar petir di tangan pengguna. Konsentrasi tinggi menghasilkan listrik mengingatkan suara kicau burung yang banyak, sesuai namanya. Setelah teknik selesai, retribusi ke depan dan menyodorkan Chidori ke target. Ini menghasilkan kerusakan berat yang biasanya berakibat fatal.', 7, N'Supreme')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (20, N'Iron Fist', N'Jurus ini memperkuat tangan penggunanya sehingga dapat memukul musuh dengan sangat kuat.', 6, N'Easy')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (22, N'Iron Armor Mark L', N'Jurus ini menciptakan baju besi besi yang sangat kuat. Armor ini juga dilengkapi panduan GPS dan kecerdasan buatan berteknologi tinggi.', 6, N'Hard')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (23, N'Keris Pusaka Mpu Gandring', N'Salah satu keris yang dicari kolektor adalah Keris Mpu Gandring. Benda pusaka ini rupanya memiliki sejarah yang berkaitan dengan salah satu kerajaan Hindu di Jawa, lebih tepatnya Kerajaan Singasari di Malang.', 6, N'Supreme')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (24, N'Wooden Vines', N'Jurus ini menciptakan sulur-sulur kayu yang dapat menjerat musuh.', 5, N'Hard')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (26, N'Wooden Forest', N'Jurus ini menciptakan hutan kayu yang dapat menyelimuti musuh.', 5, N'Hard')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (27, N'Wood Release', N'Sederhananya, Elemen Kayu memungkinkan pengguna membuat kayu. Pada puncaknya, pohon-pohon besar dengan berbagai ukuran dan bentuk dapat diciptakan. Vegetasi tersebut dapat tumbuh dari tubuh penggunanya atau tumbuh dari lingkungan sekitar', 5, N'Supreme')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (28, N'Gratifikasi', N'Jurus ini menciptakan gelombang energi uang yang dapat mempengaruhi pikiran dan perasaan musuh. Musuh akan merasa senang, puas, dan gembira sehingga mereka kehilangan fokus dan tidak dapat melawan.', 8, N'Hard')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (29, N'Money Politics', N'Jurus ini sangat kuat karena dapat digunakan untuk memanipulasi orang lain tanpa mereka sadari. Orang yang terkena jurus ini akan percaya bahwa mereka membuat keputusan sendiri, padahal sebenarnya mereka sedang dikendalikan oleh uang.', 8, N'Supreme')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (30, N'Good Looking', N'Jurus ini sangat ampuh karena dapat membuka banyak pintu bagi penggunanya. Orang yang goodlooking akan lebih mudah mendapatkan pekerjaan, promosi, atau bahkan pasangan.', NULL, N'Supreme')
INSERT [dbo].[Skill] ([ID], [Name], [Description], [ElementID], [DifficultyLevel]) VALUES (31, N'Orang Dalam', N'Jurus ini menggunakan koneksi dengan orang-orang penting untuk mendapatkan apa yang diinginkan. Jurus ini dapat digunakan untuk mendapatkan informasi, bantuan, atau bahkan keuntungan.', NULL, N'Supreme')
SET IDENTITY_INSERT [dbo].[Skill] OFF
GO
ALTER TABLE [dbo].[FightHistory]  WITH CHECK ADD  CONSTRAINT [FK_FightHistory_Hero1] FOREIGN KEY([Hero1ID])
REFERENCES [dbo].[Hero] ([ID])
GO
ALTER TABLE [dbo].[FightHistory] CHECK CONSTRAINT [FK_FightHistory_Hero1]
GO
ALTER TABLE [dbo].[FightHistory]  WITH CHECK ADD  CONSTRAINT [FK_FightHistory_Hero2] FOREIGN KEY([Hero2ID])
REFERENCES [dbo].[Hero] ([ID])
GO
ALTER TABLE [dbo].[FightHistory] CHECK CONSTRAINT [FK_FightHistory_Hero2]
GO
ALTER TABLE [dbo].[Hero]  WITH CHECK ADD  CONSTRAINT [FK_Hero_Clan] FOREIGN KEY([ClanID])
REFERENCES [dbo].[Clan] ([ID])
GO
ALTER TABLE [dbo].[Hero] CHECK CONSTRAINT [FK_Hero_Clan]
GO
ALTER TABLE [dbo].[HeroSkill]  WITH CHECK ADD  CONSTRAINT [FK_HeroSkill_Hero] FOREIGN KEY([HeroID])
REFERENCES [dbo].[Hero] ([ID])
GO
ALTER TABLE [dbo].[HeroSkill] CHECK CONSTRAINT [FK_HeroSkill_Hero]
GO
ALTER TABLE [dbo].[HeroSkill]  WITH CHECK ADD  CONSTRAINT [FK_HeroSkill_Skill] FOREIGN KEY([SkillID])
REFERENCES [dbo].[Skill] ([ID])
GO
ALTER TABLE [dbo].[HeroSkill] CHECK CONSTRAINT [FK_HeroSkill_Skill]
GO
ALTER TABLE [dbo].[Skill]  WITH CHECK ADD  CONSTRAINT [FK_Skill_Element] FOREIGN KEY([ElementID])
REFERENCES [dbo].[Element] ([ID])
GO
ALTER TABLE [dbo].[Skill] CHECK CONSTRAINT [FK_Skill_Element]
GO
ALTER TABLE [dbo].[Skill]  WITH CHECK ADD  CONSTRAINT [CK_DifficultyLevel] CHECK  (([DifficultyLevel]='Supreme' OR [DifficultyLevel]='Hard' OR [DifficultyLevel]='Medium' OR [DifficultyLevel]='Easy'))
GO
ALTER TABLE [dbo].[Skill] CHECK CONSTRAINT [CK_DifficultyLevel]
GO
USE [master]
GO
ALTER DATABASE [EsemkaHero] SET  READ_WRITE 
GO


/****** Object:  Table [dbo].[Авторы]    Script Date: 27.11.2023 22:43:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Авторы](
	[КодАвтора] [int] IDENTITY(1,1) NOT NULL,
	[ФИО] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Авторы] PRIMARY KEY CLUSTERED 
(
	[КодАвтора] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ВыдачаКниги]    Script Date: 27.11.2023 22:43:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ВыдачаКниги](
	[КодВыдачи] [int] IDENTITY(1,1) NOT NULL,
	[ИнвентарныйНомер] [int] NOT NULL,
	[КодЧитателя] [int] NOT NULL,
	[КтоВыдал] [int] NULL,
	[ДатаВыдачи] [date] NULL,
	[ДатаВозврата] [date] NULL,
 CONSTRAINT [PK_ВыдачаКниги] PRIMARY KEY CLUSTERED 
(
	[КодВыдачи] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Город]    Script Date: 27.11.2023 22:43:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Город](
	[КодГорода] [int] IDENTITY(1,1) NOT NULL,
	[Название] [varchar](168) NOT NULL,
 CONSTRAINT [PK_Город] PRIMARY KEY CLUSTERED 
(
	[КодГорода] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Жанры]    Script Date: 27.11.2023 22:43:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Жанры](
	[КодЖанра] [int] IDENTITY(1,1) NOT NULL,
	[Название] [varchar](70) NOT NULL,
 CONSTRAINT [PK_Жанры] PRIMARY KEY CLUSTERED 
(
	[КодЖанра] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Издательство]    Script Date: 27.11.2023 22:43:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Издательство](
	[КодИздательства] [int] IDENTITY(1,1) NOT NULL,
	[Название] [varchar](255) NOT NULL,
	[КодГорода] [int] NOT NULL,
 CONSTRAINT [PK_Издательство] PRIMARY KEY CLUSTERED 
(
	[КодИздательства] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ИнформацияОКниге]    Script Date: 27.11.2023 22:43:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ИнформацияОКниге](
	[ИнвентарныйНомер] [int] IDENTITY(1,1) NOT NULL,
	[Название] [varchar](255) NOT NULL,
	[КодАвтора] [int] NULL,
	[КодЖанра] [int] NULL,
	[КодИздательства] [int] NOT NULL,
	[ГодИздания] [int] NOT NULL,
	[КолвоСтраниц] [int] NOT NULL,
	[Цена] [float] NULL,
	[Фото] [varchar](max) NULL,
 CONSTRAINT [PK_ИнформаияОКниге] PRIMARY KEY CLUSTERED 
(
	[ИнвентарныйНомер] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ПаспортныеДанные]    Script Date: 27.11.2023 22:43:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ПаспортныеДанные](
	[КодПаспорта] [int] IDENTITY(1,1) NOT NULL,
	[КемВыдан] [varchar](255) NOT NULL,
	[СерияИНомер] [int] NOT NULL,
	[КодПодразделения] [int] NOT NULL,
 CONSTRAINT [PK_ПаспортныеДанные] PRIMARY KEY CLUSTERED 
(
	[КодПаспорта] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Работники]    Script Date: 27.11.2023 22:43:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Работники](
	[КодРаботника] [int] IDENTITY(1,1) NOT NULL,
	[Логин] [nvarchar](max) NOT NULL,
	[Пароль] [nvarchar](max) NOT NULL,
	[ФИО] [varchar](max) NOT NULL,
	[Фото] [nvarchar](max) NULL,
 CONSTRAINT [PK_Работники] PRIMARY KEY CLUSTERED 
(
	[КодРаботника] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Читатели]    Script Date: 27.11.2023 22:43:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Читатели](
	[КодЧитателя] [int] IDENTITY(1,1) NOT NULL,
	[ФИО] [varchar](100) NOT NULL,
	[Телефон] [varchar](12) NOT NULL,
	[КодПаспорта] [int] NOT NULL,
 CONSTRAINT [PK_ИнформацияОЧитателе] PRIMARY KEY CLUSTERED 
(
	[КодЧитателя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Авторы] ON 

INSERT [dbo].[Авторы] ([КодАвтора], [ФИО]) VALUES (1, N'Шоу Дэвид Дж.')
INSERT [dbo].[Авторы] ([КодАвтора], [ФИО]) VALUES (2, N'Король Александр')
INSERT [dbo].[Авторы] ([КодАвтора], [ФИО]) VALUES (3, N'Истомина Наталия Борисовна')
INSERT [dbo].[Авторы] ([КодАвтора], [ФИО]) VALUES (4, N'Редько Зоя Борисовна')
INSERT [dbo].[Авторы] ([КодАвтора], [ФИО]) VALUES (5, N'Секанинова Степанка')
INSERT [dbo].[Авторы] ([КодАвтора], [ФИО]) VALUES (6, N'Заболотная Этери Николаевна')
INSERT [dbo].[Авторы] ([КодАвтора], [ФИО]) VALUES (7, N'Мордкович Александр Григорьевич')
INSERT [dbo].[Авторы] ([КодАвтора], [ФИО]) VALUES (8, N'Семенов Павел Владимирович')
INSERT [dbo].[Авторы] ([КодАвтора], [ФИО]) VALUES (9, N'Акопян Арцун Владимирович')
INSERT [dbo].[Авторы] ([КодАвтора], [ФИО]) VALUES (10, N'Смолина Анна Равильевна')
INSERT [dbo].[Авторы] ([КодАвтора], [ФИО]) VALUES (11, N'Алиев Айзек')
INSERT [dbo].[Авторы] ([КодАвтора], [ФИО]) VALUES (12, N'Исаев Владимир Сергеевич')
SET IDENTITY_INSERT [dbo].[Авторы] OFF
GO
SET IDENTITY_INSERT [dbo].[ВыдачаКниги] ON 

INSERT [dbo].[ВыдачаКниги] ([КодВыдачи], [ИнвентарныйНомер], [КодЧитателя], [КтоВыдал], [ДатаВыдачи], [ДатаВозврата]) VALUES (2, 2, 2, 1, CAST(N'2023-07-11' AS Date), CAST(N'2023-12-11' AS Date))
INSERT [dbo].[ВыдачаКниги] ([КодВыдачи], [ИнвентарныйНомер], [КодЧитателя], [КтоВыдал], [ДатаВыдачи], [ДатаВозврата]) VALUES (4, 8, 3, 2, CAST(N'2023-11-18' AS Date), NULL)
INSERT [dbo].[ВыдачаКниги] ([КодВыдачи], [ИнвентарныйНомер], [КодЧитателя], [КтоВыдал], [ДатаВыдачи], [ДатаВозврата]) VALUES (7, 3, 6, 3, CAST(N'2023-09-02' AS Date), NULL)
INSERT [dbo].[ВыдачаКниги] ([КодВыдачи], [ИнвентарныйНомер], [КодЧитателя], [КтоВыдал], [ДатаВыдачи], [ДатаВозврата]) VALUES (10, 1, 9, 1, CAST(N'2023-01-11' AS Date), CAST(N'2023-02-05' AS Date))
SET IDENTITY_INSERT [dbo].[ВыдачаКниги] OFF
GO
SET IDENTITY_INSERT [dbo].[Город] ON 

INSERT [dbo].[Город] ([КодГорода], [Название]) VALUES (1, N'Москва')
INSERT [dbo].[Город] ([КодГорода], [Название]) VALUES (2, N'Санкт-Петербург')
INSERT [dbo].[Город] ([КодГорода], [Название]) VALUES (3, N'Смоленск')
INSERT [dbo].[Город] ([КодГорода], [Название]) VALUES (4, N'Ростов-на-Дону')
INSERT [dbo].[Город] ([КодГорода], [Название]) VALUES (5, N'Аксай')
INSERT [dbo].[Город] ([КодГорода], [Название]) VALUES (6, N'Иркутск')
INSERT [dbo].[Город] ([КодГорода], [Название]) VALUES (7, N'Обнинск')
INSERT [dbo].[Город] ([КодГорода], [Название]) VALUES (8, N'Волгоград')
INSERT [dbo].[Город] ([КодГорода], [Название]) VALUES (9, N'Новокузнецк')
INSERT [dbo].[Город] ([КодГорода], [Название]) VALUES (10, N'Новосибирск')
SET IDENTITY_INSERT [dbo].[Город] OFF
GO
SET IDENTITY_INSERT [dbo].[Жанры] ON 

INSERT [dbo].[Жанры] ([КодЖанра], [Название]) VALUES (1, N'Ужасы')
INSERT [dbo].[Жанры] ([КодЖанра], [Название]) VALUES (2, N'Мистика')
INSERT [dbo].[Жанры] ([КодЖанра], [Название]) VALUES (3, N'Документальная литература')
INSERT [dbo].[Жанры] ([КодЖанра], [Название]) VALUES (4, N'Научная литература')
INSERT [dbo].[Жанры] ([КодЖанра], [Название]) VALUES (5, N'Учебная литература')
INSERT [dbo].[Жанры] ([КодЖанра], [Название]) VALUES (6, N'Детектив')
INSERT [dbo].[Жанры] ([КодЖанра], [Название]) VALUES (7, N'Социально-психологическая фантастика')
INSERT [dbo].[Жанры] ([КодЖанра], [Название]) VALUES (8, N'Социальная литература')
INSERT [dbo].[Жанры] ([КодЖанра], [Название]) VALUES (10, N'Фантастика')
INSERT [dbo].[Жанры] ([КодЖанра], [Название]) VALUES (11, N'Детская литература')
SET IDENTITY_INSERT [dbo].[Жанры] OFF
GO
SET IDENTITY_INSERT [dbo].[Издательство] ON 

INSERT [dbo].[Издательство] ([КодИздательства], [Название], [КодГорода]) VALUES (1, N'Эксмо', 1)
INSERT [dbo].[Издательство] ([КодИздательства], [Название], [КодГорода]) VALUES (2, N'Астрель-СПб', 2)
INSERT [dbo].[Издательство] ([КодИздательства], [Название], [КодГорода]) VALUES (3, N'Ассоциация XXI век', 3)
INSERT [dbo].[Издательство] ([КодИздательства], [Название], [КодГорода]) VALUES (4, N'ГЕОДОМ', 4)
INSERT [dbo].[Издательство] ([КодИздательства], [Название], [КодГорода]) VALUES (5, N'Издательский дом Проф-Пресс', 5)
INSERT [dbo].[Издательство] ([КодИздательства], [Название], [КодГорода]) VALUES (6, N'Мнемозина', 6)
INSERT [dbo].[Издательство] ([КодИздательства], [Название], [КодГорода]) VALUES (7, N'Титул', 7)
INSERT [dbo].[Издательство] ([КодИздательства], [Название], [КодГорода]) VALUES (8, N'Учитель', 8)
INSERT [dbo].[Издательство] ([КодИздательства], [Название], [КодГорода]) VALUES (9, N'Союз писателей', 9)
INSERT [dbo].[Издательство] ([КодИздательства], [Название], [КодГорода]) VALUES (10, N'Академиздат', 10)
INSERT [dbo].[Издательство] ([КодИздательства], [Название], [КодГорода]) VALUES (11, N'sgsvs', 5)
SET IDENTITY_INSERT [dbo].[Издательство] OFF
GO
SET IDENTITY_INSERT [dbo].[ИнформацияОКниге] ON 

INSERT [dbo].[ИнформацияОКниге] ([ИнвентарныйНомер], [Название], [КодАвтора], [КодЖанра], [КодИздательства], [ГодИздания], [КолвоСтраниц], [Цена], [Фото]) VALUES (1, N'"Шахта"', 1, 7, 2, 2023, 512, 1095, N'/Resources/shaxta.jpg')
INSERT [dbo].[ИнформацияОКниге] ([ИнвентарныйНомер], [Название], [КодАвтора], [КодЖанра], [КодИздательства], [ГодИздания], [КолвоСтраниц], [Цена], [Фото]) VALUES (2, N'"Управление вниманием"', 2, 4, 1, 2022, 288, 1095, NULL)
INSERT [dbo].[ИнформацияОКниге] ([ИнвентарныйНомер], [Название], [КодАвтора], [КодЖанра], [КодИздательства], [ГодИздания], [КолвоСтраниц], [Цена], [Фото]) VALUES (3, N'"Математика. 6 класс. Учебник. ФГОС"', 4, 5, 3, 2019, 208, 990, NULL)
INSERT [dbo].[ИнформацияОКниге] ([ИнвентарныйНомер], [Название], [КодАвтора], [КодЖанра], [КодИздательства], [ГодИздания], [КолвоСтраниц], [Цена], [Фото]) VALUES (4, N'"Истории про великие картины и скульптуры"', 3, 3, 4, 2018, 56, 903, NULL)
INSERT [dbo].[ИнформацияОКниге] ([ИнвентарныйНомер], [Название], [КодАвтора], [КодЖанра], [КодИздательства], [ГодИздания], [КолвоСтраниц], [Цена], [Фото]) VALUES (5, N'"Дело о похищенной собаке"', 6, 11, 5, 2020, 128, 417, NULL)
INSERT [dbo].[ИнформацияОКниге] ([ИнвентарныйНомер], [Название], [КодАвтора], [КодЖанра], [КодИздательства], [ГодИздания], [КолвоСтраниц], [Цена], [Фото]) VALUES (6, N'"Математика: алгебра и начала математического анализа, геометрия. Алгебра и начала математического анализа. 10-11 классы. Учебник для общеобразовательных организаций (базовый уровень). В 2 ч. Ч. 1"', 5, 5, 6, 2015, 430, 1050, NULL)
INSERT [dbo].[ИнформацияОКниге] ([ИнвентарныйНомер], [Название], [КодАвтора], [КодЖанра], [КодИздательства], [ГодИздания], [КолвоСтраниц], [Цена], [Фото]) VALUES (7, N'"Иллюстрированный самоучитель. Настоящий английский. Предметы и действия в реальных ситуациях"', 7, 11, 7, 2017, 256, 326, NULL)
INSERT [dbo].[ИнформацияОКниге] ([ИнвентарныйНомер], [Название], [КодАвтора], [КодЖанра], [КодИздательства], [ГодИздания], [КолвоСтраниц], [Цена], [Фото]) VALUES (8, N'"НеУчебник английского"', 8, 5, 8, 2023, 32, 159, NULL)
INSERT [dbo].[ИнформацияОКниге] ([ИнвентарныйНомер], [Название], [КодАвтора], [КодЖанра], [КодИздательства], [ГодИздания], [КолвоСтраниц], [Цена], [Фото]) VALUES (9, N'"Последняя иллюзия"', 9, 10, 9, 2018, 180, 270, NULL)
INSERT [dbo].[ИнформацияОКниге] ([ИнвентарныйНомер], [Название], [КодАвтора], [КодЖанра], [КодИздательства], [ГодИздания], [КолвоСтраниц], [Цена], [Фото]) VALUES (10, N'"Формула (В поисках истины)"', 11, 8, 10, 2020, 94, 336, NULL)
SET IDENTITY_INSERT [dbo].[ИнформацияОКниге] OFF
GO
SET IDENTITY_INSERT [dbo].[ПаспортныеДанные] ON 

INSERT [dbo].[ПаспортныеДанные] ([КодПаспорта], [КемВыдан], [СерияИНомер], [КодПодразделения]) VALUES (1, N'ГУ МВД РОССИИ ПО МОСКОВСКОЙ ОБЛАСТИ', 1234123453, 213124)
INSERT [dbo].[ПаспортныеДанные] ([КодПаспорта], [КемВыдан], [СерияИНомер], [КодПодразделения]) VALUES (2, N'ОТДЕЛ ВНУТРЕННИХ ДЕЛ ГОР.КРАСНОЗНАМЕНСК', 1231313131, 123123)
INSERT [dbo].[ПаспортныеДанные] ([КодПаспорта], [КемВыдан], [СерияИНомер], [КодПодразделения]) VALUES (3, N'ОТДЕЛОМ ВНУТРЕННИХ ДЕЛ "ГОЛЬЯНОВО" ГОР. МОСКВЫ', 1232133133, 123123)
INSERT [dbo].[ПаспортныеДанные] ([КодПаспорта], [КемВыдан], [СерияИНомер], [КодПодразделения]) VALUES (4, N'ОТДЕЛОМ УФМС ПО ГОР. МОСКВЕ ПО РАЙОУ МИТИНО', 1231231231, 123132)
INSERT [dbo].[ПаспортныеДанные] ([КодПаспорта], [КемВыдан], [СерияИНомер], [КодПодразделения]) VALUES (5, N'ОТДЕЛОМ УФМС РОССИИ ПО КЕМЕРЕВСКОЙ ОБЛАСТИ', 1231231231, 123124)
INSERT [dbo].[ПаспортныеДанные] ([КодПаспорта], [КемВыдан], [СерияИНомер], [КодПодразделения]) VALUES (6, N'ГУ МВД РОССИИ ПО Г. МОСКВЕ', 6789, 312313)
INSERT [dbo].[ПаспортныеДанные] ([КодПаспорта], [КемВыдан], [СерияИНомер], [КодПодразделения]) VALUES (8, N'ГУ МВД РОССИИ ПО МОСКОВСКОЙ ОБЛАСТИ', 7890, 132131)
INSERT [dbo].[ПаспортныеДанные] ([КодПаспорта], [КемВыдан], [СерияИНомер], [КодПодразделения]) VALUES (9, N'ОТДЕЛОМ ВНУТРЕННИХ ДЕЛ "ГОЛЬЯНОВО" ГОР. МОСКВЫ', 8901, 932849)
INSERT [dbo].[ПаспортныеДанные] ([КодПаспорта], [КемВыдан], [СерияИНомер], [КодПодразделения]) VALUES (10, N'ГУ МВД РОССИИ ПО Г. МОСКВЕ', 9012, 920381)
INSERT [dbo].[ПаспортныеДанные] ([КодПаспорта], [КемВыдан], [СерияИНомер], [КодПодразделения]) VALUES (11, N'ОТДЕЛОМ УФМС ПО ГОР. МОСКВЕ ПО РАЙОУ МИТИНО', 9123, 289839)
SET IDENTITY_INSERT [dbo].[ПаспортныеДанные] OFF
GO
SET IDENTITY_INSERT [dbo].[Работники] ON 

INSERT [dbo].[Работники] ([КодРаботника], [Логин], [Пароль], [ФИО], [Фото]) VALUES (1, N'lera', N'4576D569CCB08F5E96D895C987775BCC58191CC0', N'Пелипенко Валерия Борисовна', NULL)
INSERT [dbo].[Работники] ([КодРаботника], [Логин], [Пароль], [ФИО], [Фото]) VALUES (2, N'kochet', N'67334476AD2E303192BAEF4959B66AF2B2D5593D', N'Кочетов Марк Максимович', NULL)
INSERT [dbo].[Работники] ([КодРаботника], [Логин], [Пароль], [ФИО], [Фото]) VALUES (3, N'trof', N'E90C7248D43303AAF6E2FA8412BD5199A9B78E3D', N'Трофимов Борис Владимирович', NULL)
SET IDENTITY_INSERT [dbo].[Работники] OFF
GO
SET IDENTITY_INSERT [dbo].[Читатели] ON 

INSERT [dbo].[Читатели] ([КодЧитателя], [ФИО], [Телефон], [КодПаспорта]) VALUES (2, N'Кочетов Марк Максимович', N'79168755446', 3)
INSERT [dbo].[Читатели] ([КодЧитателя], [ФИО], [Телефон], [КодПаспорта]) VALUES (3, N'Селиванова Александра Сергеевна', N'79169255446', 2)
INSERT [dbo].[Читатели] ([КодЧитателя], [ФИО], [Телефон], [КодПаспорта]) VALUES (4, N'Коновалова Екатерина Александровна', N'79169255836', 4)
INSERT [dbo].[Читатели] ([КодЧитателя], [ФИО], [Телефон], [КодПаспорта]) VALUES (5, N'Шумилина Анна Александровна', N'79047655836', 5)
INSERT [dbo].[Читатели] ([КодЧитателя], [ФИО], [Телефон], [КодПаспорта]) VALUES (6, N'Шпенглер Сергей Андреевич', N'79047655849', 6)
INSERT [dbo].[Читатели] ([КодЧитателя], [ФИО], [Телефон], [КодПаспорта]) VALUES (7, N'Табунщик Олег Эдуардович', N'79047685849', 8)
INSERT [dbo].[Читатели] ([КодЧитателя], [ФИО], [Телефон], [КодПаспорта]) VALUES (8, N'Игошина Елизавета Викторовна', N'79117685849', 9)
INSERT [dbo].[Читатели] ([КодЧитателя], [ФИО], [Телефон], [КодПаспорта]) VALUES (9, N'Денисов Павел Андреевич', N'79116525849', 10)
INSERT [dbo].[Читатели] ([КодЧитателя], [ФИО], [Телефон], [КодПаспорта]) VALUES (10, N'Панамарев Артем Павлович', N'79116528399', 11)
SET IDENTITY_INSERT [dbo].[Читатели] OFF
GO
ALTER TABLE [dbo].[ВыдачаКниги]  WITH CHECK ADD  CONSTRAINT [FK_ВыдачаКниги_ИнформацияОКниге] FOREIGN KEY([ИнвентарныйНомер])
REFERENCES [dbo].[ИнформацияОКниге] ([ИнвентарныйНомер])
GO
ALTER TABLE [dbo].[ВыдачаКниги] CHECK CONSTRAINT [FK_ВыдачаКниги_ИнформацияОКниге]
GO
ALTER TABLE [dbo].[ВыдачаКниги]  WITH CHECK ADD  CONSTRAINT [FK_ВыдачаКниги_Работники] FOREIGN KEY([КтоВыдал])
REFERENCES [dbo].[Работники] ([КодРаботника])
GO
ALTER TABLE [dbo].[ВыдачаКниги] CHECK CONSTRAINT [FK_ВыдачаКниги_Работники]
GO
ALTER TABLE [dbo].[ВыдачаКниги]  WITH CHECK ADD  CONSTRAINT [FK_ВыдачаКниги_Читатели] FOREIGN KEY([КодЧитателя])
REFERENCES [dbo].[Читатели] ([КодЧитателя])
GO
ALTER TABLE [dbo].[ВыдачаКниги] CHECK CONSTRAINT [FK_ВыдачаКниги_Читатели]
GO
ALTER TABLE [dbo].[Издательство]  WITH CHECK ADD  CONSTRAINT [FK_Издательство_Город] FOREIGN KEY([КодГорода])
REFERENCES [dbo].[Город] ([КодГорода])
GO
ALTER TABLE [dbo].[Издательство] CHECK CONSTRAINT [FK_Издательство_Город]
GO
ALTER TABLE [dbo].[ИнформацияОКниге]  WITH CHECK ADD  CONSTRAINT [FK_ИнформацияОКниге_Авторы] FOREIGN KEY([КодАвтора])
REFERENCES [dbo].[Авторы] ([КодАвтора])
GO
ALTER TABLE [dbo].[ИнформацияОКниге] CHECK CONSTRAINT [FK_ИнформацияОКниге_Авторы]
GO
ALTER TABLE [dbo].[ИнформацияОКниге]  WITH CHECK ADD  CONSTRAINT [FK_ИнформацияОКниге_Жанры] FOREIGN KEY([КодЖанра])
REFERENCES [dbo].[Жанры] ([КодЖанра])
GO
ALTER TABLE [dbo].[ИнформацияОКниге] CHECK CONSTRAINT [FK_ИнформацияОКниге_Жанры]
GO
ALTER TABLE [dbo].[ИнформацияОКниге]  WITH CHECK ADD  CONSTRAINT [FK_ИнформацияОКниге_Издательство] FOREIGN KEY([КодИздательства])
REFERENCES [dbo].[Издательство] ([КодИздательства])
GO
ALTER TABLE [dbo].[ИнформацияОКниге] CHECK CONSTRAINT [FK_ИнформацияОКниге_Издательство]
GO
ALTER TABLE [dbo].[Читатели]  WITH CHECK ADD  CONSTRAINT [FK_Читатели_ПаспортныеДанные] FOREIGN KEY([КодПаспорта])
REFERENCES [dbo].[ПаспортныеДанные] ([КодПаспорта])
GO
ALTER TABLE [dbo].[Читатели] CHECK CONSTRAINT [FK_Читатели_ПаспортныеДанные]
GO

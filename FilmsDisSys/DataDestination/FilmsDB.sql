--create table Films
--(
--  ID          int identity
--    constraint PK_Films
--    primary key,
--  NameFilm    nvarchar(max),
--  Length      int,
--  Country     nvarchar(max),
--  ReleaseDate datetime2
--)
--go

--create table Directors
--(
--  ID      int identity
--    constraint PK_Directors
--    primary key,
--  NameDirector nvarchar(max)
--)
--go

--create table Genres
--(
--  ID      int identity
--    constraint PK_Genres
--    primary key,
--  NameGenre nvarchar(max)
--)
--go

--create table Typess
--(
--  ID      int identity
--    constraint PK_Typess
--    primary key,
--  NameType nvarchar(max)
--)
--go

--create table Tags
--(
--  ID       int identity
--    constraint PK_Tags
--    primary key, 
--  NameTag  nvarchar(max)
--)
--go




--create table TagsFilms
--(
--  ID      int identity
--    constraint PK_TagsFilms
--    primary key,
--  TagsID int
--    constraint FK_TagsFilms_Tags_TagsID
--    references Tags,
--  FilmsID  int
--    constraint FK_TagsFilms_Films_FilmsID
--    references Films
--)
--go

--create index IX_TagsFilms_TagsID
--  on TagsFilms (TagsID)
--go

--create index IX_TagsFilms_FilmsID
--  on TagsFilms (FilmsID)
--go
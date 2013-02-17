CREATE TABLE Question (
	Id bigint PRIMARY KEY,
	Version int NOT NULL,
	Created_At date NOT NULL,
	Updated_On date NOT NULL,
	IsActive boolean NOT NULL,
	IsLocked boolean NOT NULL,

	Text text,
	Title text,
	User_Id int,
	Votes_Id int,
	Answers_Id int
);
CREATE TABLE Answer (
	Text text,
	IsAnswer int,
	User_Id int,
	Comment_Id int,
	Id bigint,
	Version int,
	Created_At date,
	Updated_On date
);
CREATE TABLE _User (
	Id bigint PRIMARY KEY,
	Version int NOT NULL,
	Created_At date NOT NULL,
	Updated_On date NOT NULL,
	IsActive boolean NOT NULL,
	IsLocked boolean NOT NULL,

	UserGroup_Id int NOT NULL,
	Password text NOT NULL,
	UserName text NOT NULL
);
CREATE TABLE Comment (
	Text text,
	User_Id int,
	Id int,
	Version int,
	Created_At date,
	Updated_On date
);
CREATE TABLE Vote (
	UpVotes int,
	DownVotes int,
	User_Id int,
	Id int,
	Version int,
	Created_At date,
	Updated_On date
);
CREATE TABLE Tag (
	Name text,
	Definition text,
	Tag_Id int,
	Id int,
	Version int,
	Created_At date,
	Updated_On date
);

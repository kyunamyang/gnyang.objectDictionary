1. MariaDb ���ڼ� ����

======== C:\Program Files\MariaDB 10.4\data\my.ini ========
[mysqld]
datadir=C:/Program Files/MariaDB 10.4/data
port=3306
innodb_buffer_pool_size=1014M
character-set-server=utf8
init_connect="SET collation_connection = utf8_general_ci"
init-connect='SET NAMES utf8'
collation-server = utf8_general_ci

[client]
port=3306
plugin-dir=C:/Program Files/MariaDB 10.4/lib/plugin
default-character-set=utf8

[mysql]
default-character-set=utf8

[mysqldump]
default-character-set=utf8
=========================================================
( ALTER DATABASE test CHARACTER SET = utf8mb4 COLLATE = UTF8MB4_UNICODE_CI; )
���� ������ ���� ���̺��� �ִٸ�
>> ALTER TABLE ���̺�� convert to charset utf8;
=========================================================


2. ���̺� ����

CREATE TABLE Account (
	Id 			VARCHAR(36) 	NOT NULL,
	
	Created 	DATETIME 		NOT NULL,
	Modified 	DATETIME 		NULL,
	IsDeleted 	BIT 			NOT NULL DEFAULT 0,
	
	PRIMARY KEY (Id)
);

CREATE TABLE User (
	Id 			VARCHAR(36) 	NOT NULL,
		
	`Name` 		VARCHAR(100) 	NOT NULL,
	Email		VARCHAR(100) 	NOT NULL,
	AccountId	VARCHAR(36) 	NOT NULL,
	
	Created 	DATETIME 		NOT NULL,
	Modified 	DATETIME 		NULL,
	IsDeleted 	BIT 			NOT NULL DEFAULT 0,
	
	PRIMARY KEY (Id)
);

CREATE TABLE Model (
	Id 			VARCHAR(36) 	NOT NULL,
	
	`Name` 		VARCHAR(100) 	NOT NULL,
	StartChar	CHAR(1)			NOT NULL,
	Description	VARCHAR(1000) 	NULL,
	UserId		VARCHAR(36) 	NOT NULL,
	
	Created 	DATETIME 		NOT NULL,
	Modified 	DATETIME 		NULL,
	IsDeleted 	BIT 			NOT NULL DEFAULT 0,
	
	PRIMARY KEY (Id)
);

CREATE TABLE Field (
	Id 			VARCHAR(36) 	NOT NULL,
	
	`Name` 		VARCHAR(100) 	NOT NULL,
	Description	VARCHAR(1000) 	NULL,
	UserId		VARCHAR(36) 	NOT NULL,
	ModelId		VARCHAR(36) 	NOT NULL,
	
	Created 	DATETIME 		NOT NULL,
	Modified 	DATETIME 		NULL,
	IsDeleted 	BIT 			NOT NULL DEFAULT 0,
	
	PRIMARY KEY (Id)
);

CREATE TABLE Source (
	Id 			VARCHAR(36) 	NOT NULL,
	
	`Name` 		VARCHAR(100) 	NOT NULL,
	Path		VARCHAR(1000) 	NOT NULL,
	UserId		VARCHAR(36) 	NOT NULL,
	ModelId		VARCHAR(36) 	NOT NULL,
	
	Created 	DATETIME 		NOT NULL,
	Modified 	DATETIME 		NULL,
	IsDeleted 	BIT 			NOT NULL DEFAULT 0,

	PRIMARY KEY (Id)
);


3. ���ڵ� ����

SELECT * FROM Account;
SELECT * FROM User;
SELECT * FROM Model;
SELECT * FROM Field;
SELECT * FROM Source;
SELECT * FROM Field;

INSERT INTO Account (Id, Created) VALUES ( '1D2DA715-E725-4F17-AC1A-46C1890B225F', NOW());
INSERT INTO User (Id, Name, Email, AccountId, Created) VALUES ( '302EFE24-DAA6-4C62-99D6-10DDFB4C1FB6', 'tester', 'tester@tester.co.kr', '1D2DA715-E725-4F17-AC1A-46C1890B225F', NOW());
INSERT INTO Model(Id, Name, StartChar, Description, UserId, Created) VALUES ( 'B8962F00-AEE8-418E-8AE4-B5F52EC9052F', 'Entity', 'E', '�����Դϴ�', '302EFE24-DAA6-4C62-99D6-10DDFB4C1FB6', NOW());
INSERT INTO Field(Id, Name, Description, UserId, ModelId, Created) VALUES ( '3F9E986E-54C4-471A-B1D7-ADA353EEFB76', '�Ӽ�1', '�Ӽ�1�����Դϴ�', '302EFE24-DAA6-4C62-99D6-10DDFB4C1FB6', 'B8962F00-AEE8-418E-8AE4-B5F52EC9052F', NOW());
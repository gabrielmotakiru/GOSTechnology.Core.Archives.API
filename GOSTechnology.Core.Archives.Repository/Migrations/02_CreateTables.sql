﻿-- Table Archives.
CREATE TABLE Archives
(
	Id SERIAL PRIMARY KEY NOT NULL,
	ArchiveId VARCHAR(50) NOT NULL,
	ArchiveName VARCHAR(500) NOT NULL,
	ContentType VARCHAR(100) NOT NULL,
	UserToken VARCHAR(50) NOT NULL
);
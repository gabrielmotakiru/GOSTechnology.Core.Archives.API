# GOSTechnology Core Archive API

This API in particular is intended for integration tests for sending static archives to a web server running in a docker container, with the control of these archives being done by PostgreSQL.

You can send:
  - Files in images.
  - Files in pdf.
  - Files in docx.
  - Files in pptx.

# Follow the Docker Run:
Below is the docker run for this image:
```sh
$ docker run -d -p 9999:80 -e "ArchiveConnectionString={yourConnectionStringPostgres}" --name gostechnologycorearchivesapi gabrielmotakiru/gostechnologycorearchivesapi:1.0.0
```
Docker Hub: http://hub.docker.com/r/gabrielmotakiru/gostechnologycorearchivesapi

# Considerations:
Where the **ArchiveConnectionString** parameter represents your **ConnectionString** that points to a **PostgreSQL** database.

The v1.0.0 version of this image supports the control and management of archives only in **PostgreSQL**, however, the database for control is being parameterized and will be released in a future version.

# Table Control (PostgreSQL):

-- Database DbArchive.
```sh
> CREATE DATABASE DbArchive; 
```

-- Table Archives.
```sh
CREATE TABLE Archives
(
	Id SERIAL PRIMARY KEY NOT NULL,
	ArchiveId VARCHAR(50) NOT NULL,
	ArchiveName VARCHAR(500) NOT NULL,
	ContentType VARCHAR(100) NOT NULL,
	UserToken VARCHAR(50) NOT NULL
);
```

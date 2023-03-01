## Create test Postgres database in docker

```bash
docker run -d \
  --name posgresql-14-dapper \
  -e "POSTGRES_PASSWORD=SuperWeakPassword123!" \
  -p 5432:5432 \
  postgres:14.1-alpine
# Username: postgres
# docker start posgresql-14-dapper
```

## Create Postgres database

```postgresql
CREATE DATABASE "DapperTest";
\connect "DapperTest";

CREATE TABLE "DapperTestTable1"
(
    "ID" INTEGER PRIMARY KEY,
    "Col1" VARCHAR(10),
    "Col2" VARCHAR(10)
);

CREATE TABLE "DapperTestTable2"
(
    "ID" INTEGER PRIMARY KEY,
    "Col1" VARCHAR(10),
    "Col2" VARCHAR(10)
);

INSERT INTO "DapperTestTable1" VALUES (1, 'test1col1', 'test1col2');
INSERT INTO "DapperTestTable1" VALUES (2, 'test2col1', 'test2col2');

INSERT INTO "DapperTestTable2" VALUES (1, 'test1col1', 'test1col2');
INSERT INTO "DapperTestTable2" VALUES (2, 'test2col1', 'test2col2');
INSERT INTO "DapperTestTable2" VALUES (3, 'test2col3', 'test2col3');
```
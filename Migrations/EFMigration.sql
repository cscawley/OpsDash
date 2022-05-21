CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220521063021_InitialCreate') THEN
    CREATE TABLE "Report" (
        "Id" uuid NOT NULL,
        "Date" timestamp with time zone NOT NULL,
        "SchemaVersion" integer NOT NULL,
        "ArtifactName" text NOT NULL,
        "ArtifactType" text NOT NULL,
        "MetaData" text NULL,
        "Result" text NULL,
        CONSTRAINT "PK_Report" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220521063021_InitialCreate') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220521063021_InitialCreate', '6.0.5');
    END IF;
END $EF$;
COMMIT;


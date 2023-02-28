CREATE TABLE [Developer] (
  [Developer_ID] int,
  [Name] varchar(255),
  [Email] varchar(255),
  [City] varchar(28),
  [Cellphone] varchar(15),
  PRIMARY KEY ([Developer_ID])
);

CREATE TABLE [Address] (
  [Address_ID] int,
  [Country] varchar,
  [City] varchar,
  [Latitude] decimal,
  [Longitude] decimal,
  PRIMARY KEY ([Address_ID])
);

CREATE TABLE [Event] (
  [Event_ID] int,
  [Developer_ID] int,
  [Name] varchar(300),
  [Description] varchar,
  [Date] datetime,
  [Address_ID] int,
  [City] bit,
  PRIMARY KEY ([Event_ID]),
  CONSTRAINT [FK_Event.Address_ID]
    FOREIGN KEY ([Address_ID])
      REFERENCES [Address]([Address_ID])
);

CREATE TABLE [Invitation] (
  [Invitation_ID] int,
  [Host_Developer_ID] int,
  [Event_ID] int,
  [WasAccepted] bit,
  PRIMARY KEY ([Invitation_ID])
);


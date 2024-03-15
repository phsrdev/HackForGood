CREATE TABLE Users (
    "Email" VARCHAR(255) PRIMARY KEY,
    "Username" VARCHAR(255) NOT NULL,
    "Surname" VARCHAR(255) NOT NULL,
    "Password" VARCHAR(255) NOT NULL,
    "Date" VARCHAR(10),
    "PhoneNumber" VARCHAR(16),
    "DNI" VARCHAR(10) UNIQUE NOT NULL
);



CREATE TABLE Cars (
    "Plate" VARCHAR(8) PRIMARY KEY,
    "Brand" VARCHAR(50) NOT NULL,
    "Model" VARCHAR(20) NOT NULL,
    "Color" VARCHAR(20),
    "Year" INT
);

CREATE TABLE UserCars (
    "UserID" VARCHAR(255),
    "Plate" VARCHAR(8),
    FOREIGN KEY ("UserID") REFERENCES Users("Email"),
    FOREIGN KEY ("Plate") REFERENCES Cars("Plate"),
    PRIMARY KEY ("UserID", "Plate")
);





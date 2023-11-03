CREATE TABLE Cuenta(
    id INT IDENTITY(1,1),
    email VARCHAR(300) NOT NULL,
    password_ VARCHAR(300) NOT NULL,
    id_rol INT NOT NULL

    PRIMARY KEY(id),
    FOREIGN KEY (id_rol) REFERENCES Rol(id),
    UNIQUE(email)
)
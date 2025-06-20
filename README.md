# PRUEBA TECNICA Q10

## Herramientas necesarias
- **Visual Studio 2022**
- **SQL Server Management Studio 21**
- **Postman**

## Back-end
- **.Net8**
- **ErrorOr**
- **MediatR**
- **FluentValidation**
- **Microsoft.EntityFrameworkCore.SqlServer**

## Front-end
- **.Net8**
- **Razor pages**
- **MVC**

## Ejecución
- **Se deben ejecutar los proyectos:**
### Q10.StudentManagement.Web
### Q10.StudentManagement.Api

# Creacion de la base de datos

base de datos relacional

## Crear la base de datos
```
CREATE DATABASE StudentManagementDb;
GO
```

## Usar la base de datos creada
```
USE StudentManagementDb;
GO
```

## Tabla Student
```
CREATE TABLE Student (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL,
    Document NVARCHAR(20) NOT NULL UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE
);
GO
```

## índices para la tabla Student
```
CREATE INDEX IX_Student_Document ON Student(Document);
CREATE INDEX IX_Student_Email ON Student(Email);
GO
```

## Tabla Subject
```
CREATE TABLE Subject (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL,
    Code NVARCHAR(20) NOT NULL UNIQUE,
    Credits INT NOT NULL
);
GO
```

## índices para la tabla Subject
```
CREATE INDEX IX_Subject_Code ON Subject(Code);
GO
```

## Tabla Enrollment
```
CREATE TABLE Enrollment (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    StudentId UNIQUEIDENTIFIER NOT NULL,
    SubjectId UNIQUEIDENTIFIER NOT NULL,
    RegistrationDate DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Enrollment_Student FOREIGN KEY (StudentId) REFERENCES Student(Id),
    CONSTRAINT FK_Enrollment_Subject FOREIGN KEY (SubjectId) REFERENCES Subject(Id)
);
GO
```

## índice compuesto para la tabla Enrollment
```
CREATE INDEX IX_Enrollment_StudentSubject ON Enrollment(StudentId, SubjectId);
CREATE INDEX IX_Enrollment_RegistrationDate ON Enrollment(RegistrationDate);
GO
```

## Insertar datos de prueba en la tabla Student
```
INSERT INTO Student (Name, Document, Email) VALUES
('Juan Pérez', '12345678A', 'juan.perez@email.com'),
('María García', '87654321B', 'maria.garcia@email.com'),
('Carlos López', '11223344C', 'carlos.lopez@email.com'),
('Ana Martínez', '44332211D', 'ana.martinez@email.com'),
('Luis Rodríguez', '55667788E', 'luis.rodriguez@email.com');
GO
```

## Insertar datos de prueba en la tabla Subject
```
INSERT INTO Subject (Name, Code, Credits) VALUES
('Matemáticas Avanzadas', 'MATH-101', 4),
('Programación I', 'PROG-201', 3),
('Bases de Datos', 'DB-301', 4),
('Inteligencia Artificial', 'IA-401', 5),
('Redes de Computadoras', 'NET-501', 3);
GO
```

## Insertar datos de prueba en la tabla Enrollment. Obtenemos IDs de estudiantes y materias para las inscripciones
```
DECLARE @JuanId UNIQUEIDENTIFIER, @MariaId UNIQUEIDENTIFIER, @CarlosId UNIQUEIDENTIFIER, @Anaid UNIQUEIDENTIFIER, @LuisId UNIQUEIDENTIFIER;
DECLARE @MathId UNIQUEIDENTIFIER, @ProgId UNIQUEIDENTIFIER, @DbId UNIQUEIDENTIFIER, @IaId UNIQUEIDENTIFIER, @NetId UNIQUEIDENTIFIER;

SELECT @JuanId = Id FROM Student WHERE Document = '12345678A';
SELECT @MariaId = Id FROM Student WHERE Document = '87654321B';
SELECT @CarlosId = Id FROM Student WHERE Document = '11223344C';
SELECT @Anaid = Id FROM Student WHERE Document = '44332211D';
SELECT @LuisId = Id FROM Student WHERE Document = '55667788E';

SELECT @MathId = Id FROM Subject WHERE Code = 'MATH-101';
SELECT @ProgId = Id FROM Subject WHERE Code = 'PROG-201';
SELECT @DbId = Id FROM Subject WHERE Code = 'DB-301';
SELECT @IaId = Id FROM Subject WHERE Code = 'IA-401';
SELECT @NetId = Id FROM Subject WHERE Code = 'NET-501';
```

## Insertar inscripciones
```
INSERT INTO Enrollment (StudentId, SubjectId, RegistrationDate) VALUES
(@JuanId, @MathId, DATEADD(DAY, -10, GETDATE())),
(@JuanId, @ProgId, DATEADD(DAY, -9, GETDATE())),
(@MariaId, @DbId, DATEADD(DAY, -8, GETDATE())),
(@MariaId, @IaId, DATEADD(DAY, -7, GETDATE())),
(@CarlosId, @NetId, DATEADD(DAY, -6, GETDATE())),
(@CarlosId, @MathId, DATEADD(DAY, -5, GETDATE())),
(@Anaid, @ProgId, DATEADD(DAY, -4, GETDATE())),
(@Anaid, @DbId, DATEADD(DAY, -3, GETDATE())),
(@LuisId, @IaId, DATEADD(DAY, -2, GETDATE())),
(@LuisId, @NetId, DATEADD(DAY, -1, GETDATE()));
GO
```
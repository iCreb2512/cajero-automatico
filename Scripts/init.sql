-- ============================================================
--  Scripts/init.sql
--  Inicialización de la base de datos del Cajero Automático
-- ============================================================

PRAGMA foreign_keys = ON;

-- Tabla de usuarios (titulares de tarjeta)
CREATE TABLE IF NOT EXISTS Usuarios (
    Id             INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre         TEXT    NOT NULL,
    NumeroTarjeta  TEXT    NOT NULL UNIQUE,
    PIN            TEXT    NOT NULL,
    Saldo          REAL    NOT NULL DEFAULT 0.00
);

-- Tabla de transacciones (historial de movimientos)
CREATE TABLE IF NOT EXISTS Transacciones (
    Id         INTEGER PRIMARY KEY AUTOINCREMENT,
    UsuarioId  INTEGER NOT NULL,
    Tipo       TEXT    NOT NULL,   -- 'Deposito' o 'Retiro'
    Monto      REAL    NOT NULL,
    Fecha      TEXT    NOT NULL DEFAULT (datetime('now')),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);

-- Datos de prueba
INSERT OR IGNORE INTO Usuarios (Nombre, NumeroTarjeta, PIN, Saldo)
VALUES
    ('Juan Pérez',  '4111111111111111', '1234', 1500.00),
    ('María López', '5500005555555559', '5678', 3200.50);
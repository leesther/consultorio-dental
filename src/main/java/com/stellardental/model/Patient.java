package com.stellardental.model;

public class Patient {
    private final long id;
    private final String nombre;
    private final String apellido;
    private final String dni;
    private final String email;
    private final String telefono;

    public Patient(long id, String nombre, String apellido, String dni, String email, String telefono) {
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
        this.dni = dni;
        this.email = email;
        this.telefono = telefono;
    }

    public long getId() {
        return id;
    }

    public String getNombre() {
        return nombre;
    }

    public String getApellido() {
        return apellido;
    }

    public String getDni() {
        return dni;
    }

    public String getEmail() {
        return email;
    }

    public String getTelefono() {
        return telefono;
    }

    public String getNombreCompleto() {
        return (nombre + " " + apellido).trim();
    }

    public String getIniciales() {
        String n = nombre == null || nombre.isBlank() ? "P" : nombre.substring(0, 1);
        String a = apellido == null || apellido.isBlank() ? "" : apellido.substring(0, 1);
        return (n + a).toUpperCase();
    }
}

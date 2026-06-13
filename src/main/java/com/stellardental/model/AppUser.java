package com.stellardental.model;

public class AppUser {
    private final long id;
    private final String nombre;
    private final String apellido;
    private final String email;
    private final int rolId;

    public AppUser(long id, String nombre, String apellido, String email, int rolId) {
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
        this.email = email;
        this.rolId = rolId;
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

    public String getEmail() {
        return email;
    }

    public int getRolId() {
        return rolId;
    }

    public String getNombreCompleto() {
        return (nombre + " " + apellido).trim();
    }
}

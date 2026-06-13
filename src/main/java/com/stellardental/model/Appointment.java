package com.stellardental.model;

import java.time.LocalDateTime;

public class Appointment {
    private final long id;
    private final LocalDateTime inicio;
    private final LocalDateTime fin;
    private final String motivo;
    private final String estado;
    private final String doctor;

    public Appointment(long id, LocalDateTime inicio, LocalDateTime fin, String motivo, String estado, String doctor) {
        this.id = id;
        this.inicio = inicio;
        this.fin = fin;
        this.motivo = motivo;
        this.estado = estado;
        this.doctor = doctor;
    }

    public long getId() {
        return id;
    }

    public LocalDateTime getInicio() {
        return inicio;
    }

    public LocalDateTime getFin() {
        return fin;
    }

    public String getMotivo() {
        return motivo;
    }

    public String getEstado() {
        return estado;
    }

    public String getDoctor() {
        return doctor;
    }
}

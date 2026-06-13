package com.stellardental.model;

import java.time.LocalDateTime;

public class ClinicalRecord {
    private final LocalDateTime fecha;
    private final String diagnostico;
    private final String tratamiento;
    private final String observaciones;

    public ClinicalRecord(LocalDateTime fecha, String diagnostico, String tratamiento, String observaciones) {
        this.fecha = fecha;
        this.diagnostico = diagnostico;
        this.tratamiento = tratamiento;
        this.observaciones = observaciones;
    }

    public LocalDateTime getFecha() {
        return fecha;
    }

    public String getDiagnostico() {
        return diagnostico;
    }

    public String getTratamiento() {
        return tratamiento;
    }

    public String getObservaciones() {
        return observaciones;
    }
}

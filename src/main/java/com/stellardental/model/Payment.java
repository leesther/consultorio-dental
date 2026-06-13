package com.stellardental.model;

import java.math.BigDecimal;
import java.time.LocalDateTime;

public class Payment {
    private final LocalDateTime fechaPago;
    private final LocalDateTime fechaVencimiento;
    private final String metodo;
    private final String estado;
    private final BigDecimal monto;
    private final BigDecimal montoPendiente;
    private final String observaciones;
    private final boolean deuda;

    public Payment(LocalDateTime fechaPago, LocalDateTime fechaVencimiento, String metodo, String estado,
                   BigDecimal monto, BigDecimal montoPendiente, String observaciones, boolean deuda) {
        this.fechaPago = fechaPago;
        this.fechaVencimiento = fechaVencimiento;
        this.metodo = metodo;
        this.estado = estado;
        this.monto = monto;
        this.montoPendiente = montoPendiente;
        this.observaciones = observaciones;
        this.deuda = deuda;
    }

    public LocalDateTime getFechaPago() {
        return fechaPago;
    }

    public LocalDateTime getFechaVencimiento() {
        return fechaVencimiento;
    }

    public String getMetodo() {
        return metodo;
    }

    public String getEstado() {
        return estado;
    }

    public BigDecimal getMonto() {
        return monto;
    }

    public BigDecimal getMontoPendiente() {
        return montoPendiente;
    }

    public String getObservaciones() {
        return observaciones;
    }

    public boolean isDeuda() {
        return deuda;
    }
}

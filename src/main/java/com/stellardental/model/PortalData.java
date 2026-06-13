package com.stellardental.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

public class PortalData {
    private Patient patient;
    private Appointment nextAppointment;
    private List<ClinicalRecord> clinicalRecords = new ArrayList<>();
    private List<Payment> payments = new ArrayList<>();
    private String odontogramObservations = "";
    private int odontogramFindings;
    private BigDecimal totalPagado = BigDecimal.ZERO;
    private BigDecimal saldoPendiente = BigDecimal.ZERO;

    public Patient getPatient() {
        return patient;
    }

    public void setPatient(Patient patient) {
        this.patient = patient;
    }

    public Appointment getNextAppointment() {
        return nextAppointment;
    }

    public void setNextAppointment(Appointment nextAppointment) {
        this.nextAppointment = nextAppointment;
    }

    public List<ClinicalRecord> getClinicalRecords() {
        return clinicalRecords;
    }

    public void setClinicalRecords(List<ClinicalRecord> clinicalRecords) {
        this.clinicalRecords = clinicalRecords;
    }

    public List<Payment> getPayments() {
        return payments;
    }

    public void setPayments(List<Payment> payments) {
        this.payments = payments;
    }

    public String getOdontogramObservations() {
        return odontogramObservations;
    }

    public void setOdontogramObservations(String odontogramObservations) {
        this.odontogramObservations = odontogramObservations;
    }

    public int getOdontogramFindings() {
        return odontogramFindings;
    }

    public void setOdontogramFindings(int odontogramFindings) {
        this.odontogramFindings = odontogramFindings;
    }

    public BigDecimal getTotalPagado() {
        return totalPagado;
    }

    public void setTotalPagado(BigDecimal totalPagado) {
        this.totalPagado = totalPagado;
    }

    public BigDecimal getSaldoPendiente() {
        return saldoPendiente;
    }

    public void setSaldoPendiente(BigDecimal saldoPendiente) {
        this.saldoPendiente = saldoPendiente;
    }
}

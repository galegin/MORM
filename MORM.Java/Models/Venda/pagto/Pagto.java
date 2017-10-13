package br.com.virtual.model.pagto;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

import java.util.Date;

@Entity(cod="PAGTO")
public class Pagto extends _PersistDAO {
 
	@Column(cod="CD_PAGTO", des="Cod. Pagto", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdPagto;
	 
	@Column(cod="DT_PAGTO", des="Dt. Pagto", tpf=TipoField.REQ, tpd=TipoDado.DATAHORA, tam=10, dec=0)
	private Date dtPagto;
	 
	@Column(cod="VL_PAGTO", des="Vl. Pagto", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlPagto;
	 
	@Column(cod="CD_OPERCX", des="Cod. Opercx", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdOperCx;

	public Integer getCdPagto() { return cdPagto; } 
	public void setCdPagto(Integer cdPagto) { 
		this.cdPagto = cdPagto; 
	}

	public Date getDtPagto() { return dtPagto; } 
	public void setDtPagto(Date dtPagto) { 
		this.dtPagto = dtPagto; 
	}

	public Float getVlPagto() { return vlPagto; } 
	public void setVlPagto(Float vlPagto) { 
		this.vlPagto = vlPagto; 
	}

	public Integer getCdOperCx() { return cdOperCx; } 
	public void setCdOperCx(Integer cdOperCx) { 
		this.cdOperCx = cdOperCx; 
	}
	 
}
 

package br.com.virtual.model.logradouro;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="MUNICIPIO")
public class Municipio extends _PersistDAO {
 
	@Column(cod="CD_MUNICIPIO", des="Cod. Municipio", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdMunicipio;
	 
	@Column(cod="DS_MUNICIPIO", des="Ds. Municipio", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsMunicipio;
	 
	@Column(cod="TP_MUNICIPIO", des="Tp. Municipio", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer tpMunicipio;
	 
	@Column(cod="CD_ESTADO", des="Cod. Estado", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0, cls="Estado")
	private Integer cdEstado;
	 
	@Column(cod="IN_CAPITAL", des="Capital", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=1, dec=0)
	private Boolean inCapital;
	 
	@Column(cod="DS_SIGLA", des="Ds. Sigla", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsSigla;

	public Integer getCdMunicipio() { return cdMunicipio; } 
	public void setCdMunicipio(Integer cdMunicipio) { 
		this.cdMunicipio = cdMunicipio; 
	}

	public String getDsMunicipio() { return dsMunicipio; } 
	public void setDsMunicipio(String dsMunicipio) { 
		this.dsMunicipio = dsMunicipio; 
	}

	public Integer getTpMunicipio() { return tpMunicipio; } 
	public void setTpMunicipio(Integer tpMunicipio) { 
		this.tpMunicipio = tpMunicipio; 
	}

	public Integer getCdEstado() { return cdEstado; } 
	public void setCdEstado(Integer cdEstado) { 
		this.cdEstado = cdEstado; 
	}

	public Boolean getInCapital() { return inCapital; } 
	public void setInCapital(Boolean inCapital) { 
		this.inCapital = inCapital; 
	}

	public String getDsSigla() { return dsSigla; } 
	public void setDsSigla(String dsSigla) { 
		this.dsSigla = dsSigla; 
	}
	 
}
 

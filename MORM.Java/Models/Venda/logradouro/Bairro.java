package br.com.virtual.model.logradouro;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="BAIRRO")
public class Bairro extends _PersistDAO {
 
	@Column(cod="CD_MUNICIPIO", des="Cod. Municipio", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0, cls="Municipio")
	private Integer cdMunicipio;
	 
	@Column(cod="CD_BAIRRO", des="Cod. Bairro", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdBairro;
	 
	@Column(cod="DS_BAIRRO", des="Ds. Bairro", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsBairro;
	 
	@Column(cod="DS_ABREV", des="Ds. Abrev", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsAbrev;

	public Integer getCdMunicipio() { return cdMunicipio; } 
	public void setCdMunicipio(Integer cdMunicipio) { 
		this.cdMunicipio = cdMunicipio; 
	}

	public Integer getCdBairro() { return cdBairro; } 
	public void setCdBairro(Integer cdBairro) { 
		this.cdBairro = cdBairro; 
	}

	public String getDsBairro() { return dsBairro; } 
	public void setDsBairro(String dsBairro) { 
		this.dsBairro = dsBairro; 
	}

	public String getDsAbrev() { return dsAbrev; } 
	public void setDsAbrev(String dsAbrev) { 
		this.dsAbrev = dsAbrev; 
	}
	 
}
 

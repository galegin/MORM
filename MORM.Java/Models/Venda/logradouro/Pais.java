package br.com.virtual.model.logradouro;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="PAIS")
public class Pais extends _PersistDAO {
 
	@Column(cod="CD_PAIS", des="Cod. Pais", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdPais;
	 
	@Column(cod="DS_PAIS", des="Ds. Pais", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsPais;

	public Integer getCdPais() { return cdPais; } 
	public void setCdPais(Integer cdPais) { 
		this.cdPais = cdPais; 
	}

	public String getDsPais() { return dsPais; } 
	public void setDsPais(String dsPais) { 
		this.dsPais = dsPais; 
	}
	 
}
 

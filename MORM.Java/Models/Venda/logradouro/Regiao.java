package br.com.virtual.model.logradouro;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="REGIAO")
public class Regiao extends _PersistDAO {
 
	@Column(cod="CD_REGIAO", des="Cod. Regiao", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdRegiao;
	 
	@Column(cod="DS_REGIAO", des="Ds. Regiao", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsRegiao;

	public Integer getCdRegiao() { return cdRegiao; } 
	public void setCdRegiao(Integer cdRegiao) { 
		this.cdRegiao = cdRegiao; 
	}

	public String getDsRegiao() { return dsRegiao; } 
	public void setDsRegiao(String dsRegiao) { 
		this.dsRegiao = dsRegiao; 
	}
	 
}
 

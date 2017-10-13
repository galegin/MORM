package br.com.virtual.model.produto;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="COR")
public class Cor extends _PersistDAO {
 
	@Column(cod="CD_COR", des="Cod. Cor", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdCor;
	 
	@Column(cod="DS_COR", des="Ds. Cor", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsCor;

	public Integer getCdCor() { return cdCor; } 
	public void setCdCor(Integer cdCor) { 
		this.cdCor = cdCor; 
	}

	public String getDsCor() { return dsCor; } 
	public void setDsCor(String dsCor) { 
		this.dsCor = dsCor; 
	}
	 
}
 

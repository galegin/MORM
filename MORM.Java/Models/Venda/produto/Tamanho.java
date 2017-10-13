package br.com.virtual.model.produto;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="TAMANHO")
public class Tamanho extends _PersistDAO {
 
	@Column(cod="CD_TAMANHO", des="Cod. Tamanho", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdTamanho;
	 
	@Column(cod="DS_TAMANHO", des="Ds. Tamanho", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsTamanho;

	public Integer getCdTamanho() { return cdTamanho; } 
	public void setCdTamanho(Integer cdTamanho) { 
		this.cdTamanho = cdTamanho; 
	}

	public String getDsTamanho() { return dsTamanho; } 
	public void setDsTamanho(String dsTamanho) { 
		this.dsTamanho = dsTamanho; 
	}
	 
}
 

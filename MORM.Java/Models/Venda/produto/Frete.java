package br.com.virtual.model.produto;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="FRETE")
public class Frete extends _PersistDAO {
 
	@Column(cod="CD_FRETE", des="Cod. Frete", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdFrete;
	 
	@Column(cod="DS_FRETE", des="Ds. Frete", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsFrete;
	 
	@Column(cod="TP_FRETE", des="Tp. Frete", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer tpFrete;
	 
	@Column(cod="CD_REGIAO", des="Cod. Regiao", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdRegiao;

	public Integer getCdFrete() { return cdFrete; } 
	public void setCdFrete(Integer cdFrete) { 
		this.cdFrete = cdFrete; 
	}

	public String getDsFrete() { return dsFrete; } 
	public void setDsFrete(String dsFrete) { 
		this.dsFrete = dsFrete; 
	}

	public Integer getTpFrete() { return tpFrete; } 
	public void setTpFrete(Integer tpFrete) { 
		this.tpFrete = tpFrete; 
	}

	public Integer getCdRegiao() { return cdRegiao; } 
	public void setCdRegiao(Integer cdRegiao) { 
		this.cdRegiao = cdRegiao; 
	}
	 
}
 

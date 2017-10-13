package br.com.virtual.model.produto;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="PRODUTO")
public class Produto extends _PersistDAO {
 
	@Column(cod="CD_PRODUTO", des="Cod. Produto", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdProduto;
	 
	@Column(cod="DS_PRODUTO", des="Ds. Produto", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsProduto;
	 
	@Column(cod="CD_GRUPO", des="Cod. Grupo", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdGrupo;
	 
	@Column(cod="CD_COR", des="Cod. Cor", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdCor;
	 
	@Column(cod="CD_TAMANHO", des="Cod. Tamanho", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdTamanho;
	 
	@Column(cod="CD_ESPECIE", des="Cod. Especie", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=10, dec=0)
	private String cdEspecie;
	 
	@Column(cod="VL_PRODUTO", des="Vl. Produto", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlProduto;
	 
	@Column(cod="VL_PROMOCAO", des="Vl. Promoção", tpf=TipoField.NUL, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlPromocao;
	 
	@Column(cod="QT_PROMOCAO", des="Qt. Promoção", tpf=TipoField.NUL, tpd=TipoDado.NUMERO, tam=10, dec=3)
	private Float qtPromocao;
	 
	@Column(cod="PR_ICMS", des="Pr. Icms", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=3)
	private Float prICMS;
	 
	@Column(cod="PR_IPI", des="Pr. Ipi", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=3)
	private Float prIPI;
	 
	@Column(cod="CD_NCM", des="Cod. Ncm", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=10, dec=0)
	private String cdNCM;
	 
	@Column(cod="CD_CST", des="Cod. Cst", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=10, dec=0)
	private String cdCST;
	 
	@Column(cod="CD_CFOP", des="Cod. Cfop", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=10, dec=0)
	private String cdCFOP;
	 
	@Column(cod="CD_FRETE", des="Cod. Frete", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdFrete;

	public Integer getCdProduto() { return cdProduto; } 
	public void setCdProduto(Integer cdProduto) { 
		this.cdProduto = cdProduto; 
	}

	public String getDsProduto() { return dsProduto; } 
	public void setDsProduto(String dsProduto) { 
		this.dsProduto = dsProduto; 
	}

	public Integer getCdGrupo() { return cdGrupo; } 
	public void setCdGrupo(Integer cdGrupo) { 
		this.cdGrupo = cdGrupo; 
	}

	public Integer getCdCor() { return cdCor; } 
	public void setCdCor(Integer cdCor) { 
		this.cdCor = cdCor; 
	}

	public Integer getCdTamanho() { return cdTamanho; } 
	public void setCdTamanho(Integer cdTamanho) { 
		this.cdTamanho = cdTamanho; 
	}

	public String getCdEspecie() { return cdEspecie; } 
	public void setCdEspecie(String cdEspecie) { 
		this.cdEspecie = cdEspecie; 
	}

	public Float getVlProduto() { return vlProduto; } 
	public void setVlProduto(Float vlProduto) { 
		this.vlProduto = vlProduto; 
	}

	public Float getVlPromocao() { return vlPromocao; } 
	public void setVlPromocao(Float vlPromocao) { 
		this.vlPromocao = vlPromocao; 
	}

	public Float getQtPromocao() { return qtPromocao; } 
	public void setQtPromocao(Float qtPromocao) { 
		this.qtPromocao = qtPromocao; 
	}

	public Float getPrICMS() { return prICMS; } 
	public void setPrICMS(Float prICMS) { 
		this.prICMS = prICMS; 
	}

	public Float getPrIPI() { return prIPI; } 
	public void setPrIPI(Float prIPI) { 
		this.prIPI = prIPI; 
	}

	public String getCdNCM() { return cdNCM; } 
	public void setCdNCM(String cdNCM) { 
		this.cdNCM = cdNCM; 
	}

	public String getCdCST() { return cdCST; } 
	public void setCdCST(String cdCST) { 
		this.cdCST = cdCST; 
	}

	public String getCdCFOP() { return cdCFOP; } 
	public void setCdCFOP(String cdCFOP) { 
		this.cdCFOP = cdCFOP; 
	}

	public Integer getCdFrete() { return cdFrete; } 
	public void setCdFrete(Integer cdFrete) { 
		this.cdFrete = cdFrete; 
	}
	 
}
 

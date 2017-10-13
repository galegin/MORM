package br.com.virtual.model.produto;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="PRODUTODESCTO")
public class ProdutoDescto extends _PersistDAO {
 
	@Column(cod="CD_PRODUTO", des="Cod. Produto", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdProduto;
	 
	@Column(cod="CD_FORMA", des="Cod. Forma", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdForma;
	 
	@Column(cod="PR_DESCONTO", des="Pr. Desconto", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=3)
	private Float prDesconto;

	public Integer getCdProduto() { return cdProduto; } 
	public void setCdProduto(Integer cdProduto) { 
		this.cdProduto = cdProduto; 
	}

	public Integer getCdForma() { return cdForma; } 
	public void setCdForma(Integer cdForma) { 
		this.cdForma = cdForma; 
	}

	public Float getPrDesconto() { return prDesconto; } 
	public void setPrDesconto(Float prDesconto) { 
		this.prDesconto = prDesconto; 
	}
	 
}
 

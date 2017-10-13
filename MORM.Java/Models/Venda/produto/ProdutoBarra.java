package br.com.virtual.model.produto;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="PRODUTOBARRA")
public class ProdutoBarra extends _PersistDAO {
	 
	@Column(cod="CD_BARRA", des="Cod. Barra", tpf=TipoField.KEY, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String cdBarra;

	@Column(cod="CD_PRODUTO", des="Cod. Produto", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdProduto;

	public String getCdBarra() { return cdBarra; } 
	public void setCdBarra(String cdBarra) { 
		this.cdBarra = cdBarra; 
	}
	
	public Integer getCdProduto() { return cdProduto; } 
	public void setCdProduto(Integer cdProduto) { 
		this.cdProduto = cdProduto; 
	}	
	 
}
 

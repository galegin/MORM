package br.com.virtual.model.venda;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="VENDAITEM")
public class VendaItem extends _PersistDAO {
 
	@Column(cod="CD_VENDA", des="Cod. Venda", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdVenda;
	 
	@Column(cod="CD_PRODUTO", des="Cod. Produto", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdProduto;
	 
	@Column(cod="DS_PRODUTO", des="Ds. Produto", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsProduto;
	 
	@Column(cod="CD_ESPECIE", des="Cod. Especie", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=10, dec=0)
	private String cdEspecie;
	 
	@Column(cod="QT_PRODUTO", des="Qt. Produto", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=3)
	private Float qtProduto;
	 
	@Column(cod="VL_PRODUTO", des="Vl. Produto", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlProduto;
	 
	@Column(cod="VL_IMPOSTO", des="Vl. Imposto", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlImposto;
	 
	@Column(cod="VL_DESCONTO", des="Vl. Desconto", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlDesconto;
	 
	@Column(cod="VL_TOTAL", des="Vl. Total", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlTotal;

	public Integer getCdVenda() { return cdVenda; } 
	public void setCdVenda(Integer cdVenda) { 
		this.cdVenda = cdVenda; 
	}

	public Integer getCdProduto() { return cdProduto; } 
	public void setCdProduto(Integer cdProduto) { 
		this.cdProduto = cdProduto; 
	}

	public String getDsProduto() { return dsProduto; } 
	public void setDsProduto(String dsProduto) { 
		this.dsProduto = dsProduto; 
	}

	public String getCdEspecie() { return cdEspecie; } 
	public void setCdEspecie(String cdEspecie) { 
		this.cdEspecie = cdEspecie; 
	}

	public Float getQtProduto() { return qtProduto; } 
	public void setQtProduto(Float qtProduto) { 
		this.qtProduto = qtProduto; 
	}

	public Float getVlProduto() { return vlProduto; } 
	public void setVlProduto(Float vlProduto) { 
		this.vlProduto = vlProduto; 
	}

	public Float getVlImposto() { return vlImposto; } 
	public void setVlImposto(Float vlImposto) { 
		this.vlImposto = vlImposto; 
	}

	public Float getVlDesconto() { return vlDesconto; } 
	public void setVlDesconto(Float vlDesconto) { 
		this.vlDesconto = vlDesconto; 
	}

	public Float getVlTotal() { return vlTotal; } 
	public void setVlTotal(Float vlTotal) { 
		this.vlTotal = vlTotal; 
	}
	 
}
 

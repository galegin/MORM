package br.com.virtual.model.pedido;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

import java.util.Date;

@Entity(cod="PEDIDO")
public class Pedido extends _PersistDAO {
 
	@Column(cod="CD_PEDIDO", des="Cod. Pedido", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdPedido;
	 
	@Column(cod="CD_LOJA", des="Cod. Loja", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdLoja;
	 
	@Column(cod="CD_TERMINAL", des="Cod. Terminal", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdTerminal;
	 
	@Column(cod="DT_PEDIDO", des="Dt. Pedido", tpf=TipoField.REQ, tpd=TipoDado.DATAHORA, tam=10, dec=0)
	private Date dtPedido;
	 
	@Column(cod="CD_CLIENTE", des="Cod. Cliente", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdCliente;
	 
	@Column(cod="TP_SITUACAO", des="Tp. Situação", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer tpSituacao;
	 
	@Column(cod="VL_PRODUTO", des="Vl. Produto", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlProduto;
	 
	@Column(cod="VL_IMPOSTO", des="Vl. Imposto", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlImposto;
	 
	@Column(cod="VL_DESCONTO", des="Vl. Desconto", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlDesconto;
	 
	@Column(cod="VL_ACRESCIMO", des="Vl. Acrescimo", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlAcrescimo;
	 
	@Column(cod="VL_TOTAL", des="Vl. Total", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlTotal;

	public Integer getCdPedido() { return cdPedido; } 
	public void setCdPedido(Integer cdPedido) { 
		this.cdPedido = cdPedido; 
	}

	public Integer getCdLoja() { return cdLoja; } 
	public void setCdLoja(Integer cdLoja) { 
		this.cdLoja = cdLoja; 
	}

	public Integer getCdTerminal() { return cdTerminal; } 
	public void setCdTerminal(Integer cdTerminal) { 
		this.cdTerminal = cdTerminal; 
	}

	public Date getDtPedido() { return dtPedido; } 
	public void setDtPedido(Date dtPedido) { 
		this.dtPedido = dtPedido; 
	}

	public Integer getCdCliente() { return cdCliente; } 
	public void setCdCliente(Integer cdCliente) { 
		this.cdCliente = cdCliente; 
	}

	public Integer getTpSituacao() { return tpSituacao; } 
	public void setTpSituacao(Integer tpSituacao) { 
		this.tpSituacao = tpSituacao; 
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

	public Float getVlAcrescimo() { return vlAcrescimo; } 
	public void setVlAcrescimo(Float vlAcrescimo) { 
		this.vlAcrescimo = vlAcrescimo; 
	}

	public Float getVlTotal() { return vlTotal; } 
	public void setVlTotal(Float vlTotal) { 
		this.vlTotal = vlTotal; 
	}
	 
}
 

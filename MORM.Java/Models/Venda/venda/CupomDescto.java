package br.com.virtual.model.venda;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

import java.util.Date;

@Entity(cod="CUPOMDESCTO")
public class CupomDescto extends _PersistDAO {
 
	@Column(cod="CD_CUPOM", des="Cod. Cupom", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdCupom;
	 
	@Column(cod="VL_CUPOM", des="Vl. Cupom", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlCupom;
	 
	@Column(cod="PR_CUPOM", des="Pr. Cupom", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=3)
	private Float prCupom;
	 
	@Column(cod="DT_VALIDADE", des="Dt. Validade", tpf=TipoField.REQ, tpd=TipoDado.DATAHORA, tam=10, dec=0)
	private Date dtValidade;
	 
	@Column(cod="CD_CLIENTE", des="Cod. Cliente", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdCliente;
	 
	@Column(cod="CD_VENDA", des="Cod. Venda", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdVenda;

	public Integer getCdCupom() { return cdCupom; } 
	public void setCdCupom(Integer cdCupom) { 
		this.cdCupom = cdCupom; 
	}

	public Float getVlCupom() { return vlCupom; } 
	public void setVlCupom(Float vlCupom) { 
		this.vlCupom = vlCupom; 
	}

	public Float getPrCupom() { return prCupom; } 
	public void setPrCupom(Float prCupom) { 
		this.prCupom = prCupom; 
	}

	public Date getDtValidade() { return dtValidade; } 
	public void setDtValidade(Date dtValidade) { 
		this.dtValidade = dtValidade; 
	}

	public Integer getCdCliente() { return cdCliente; } 
	public void setCdCliente(Integer cdCliente) { 
		this.cdCliente = cdCliente; 
	}

	public Integer getCdVenda() { return cdVenda; } 
	public void setCdVenda(Integer cdVenda) { 
		this.cdVenda = cdVenda; 
	}
	 
}
 

package br.com.virtual.model.pagto;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="PAGTOFORMA")
public class PagtoForma extends _PersistDAO {
 
	@Column(cod="CD_PAGTO", des="Cod. Pagto", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdPagto;
	 
	@Column(cod="CD_FORMA", des="Cod. Forma", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdForma;
	 
	@Column(cod="TP_DOCTO", des="Tp. Docto", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer tpDocto;
	 
	@Column(cod="VL_DOCTO", des="Vl. Docto", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlDocto;
	 
	@Column(cod="NR_PARCELAS", des="Nr. Parcelas", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer nrParcelas;
	 
	@Column(cod="CD_OPERADORA", des="Cod. Operadora", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdOperadora;
	 
	@Column(cod="CD_AUTORIZACAO", des="Cod. Autorização", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=10, dec=0)
	private String cdAutorizacao;
	 
	@Column(cod="NR_NSU", des="Nr. Nsu", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=10, dec=0)
	private String nrNSU;

	public Integer getCdPagto() { return cdPagto; } 
	public void setCdPagto(Integer cdPagto) { 
		this.cdPagto = cdPagto; 
	}

	public Integer getCdForma() { return cdForma; } 
	public void setCdForma(Integer cdForma) { 
		this.cdForma = cdForma; 
	}

	public Integer getTpDocto() { return tpDocto; } 
	public void setTpDocto(Integer tpDocto) { 
		this.tpDocto = tpDocto; 
	}

	public Float getVlDocto() { return vlDocto; } 
	public void setVlDocto(Float vlDocto) { 
		this.vlDocto = vlDocto; 
	}

	public Integer getNrParcelas() { return nrParcelas; } 
	public void setNrParcelas(Integer nrParcelas) { 
		this.nrParcelas = nrParcelas; 
	}

	public Integer getCdOperadora() { return cdOperadora; } 
	public void setCdOperadora(Integer cdOperadora) { 
		this.cdOperadora = cdOperadora; 
	}

	public String getCdAutorizacao() { return cdAutorizacao; } 
	public void setCdAutorizacao(String cdAutorizacao) { 
		this.cdAutorizacao = cdAutorizacao; 
	}

	public String getNrNSU() { return nrNSU; } 
	public void setNrNSU(String nrNSU) { 
		this.nrNSU = nrNSU; 
	}
	 
}
 

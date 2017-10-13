package br.com.virtual.model.pagto;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="FORMA")
public class Forma extends _PersistDAO {
 
	@Column(cod="CD_FORMA", des="Cod. Forma", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdForma;
	 
	@Column(cod="DS_FORMA", des="Ds. Forma", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsForma;
	 
	@Column(cod="CD_OPERADORA", des="Cod. Operadora", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdOperadora;
	 
	@Column(cod="NR_PARCELAS", des="Nr. Parcelas", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer nrParcelas;

	public Integer getCdForma() { return cdForma; } 
	public void setCdForma(Integer cdForma) { 
		this.cdForma = cdForma; 
	}

	public String getDsForma() { return dsForma; } 
	public void setDsForma(String dsForma) { 
		this.dsForma = dsForma; 
	}

	public Integer getCdOperadora() { return cdOperadora; } 
	public void setCdOperadora(Integer cdOperadora) { 
		this.cdOperadora = cdOperadora; 
	}

	public Integer getNrParcelas() { return nrParcelas; } 
	public void setNrParcelas(Integer nrParcelas) { 
		this.nrParcelas = nrParcelas; 
	}
	 
}
 

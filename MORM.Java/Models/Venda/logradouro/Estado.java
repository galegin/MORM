package br.com.virtual.model.logradouro;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="ESTADO")
public class Estado extends _PersistDAO {
 
	@Column(cod="CD_ESTADO", des="Cod. Estado", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdEstado;
	 
	@Column(cod="DS_ESTADO", des="Ds. Estado", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsEstado;
	 
	@Column(cod="CD_PAIS", des="Cod. Pais", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0, cls="Pais")
	private Integer cdPais;
	 
	@Column(cod="CD_REGIAO", des="Cod. Regiao", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0, cls="Regiao")
	private Integer cdRegiao;
	 
	@Column(cod="DS_SIGLA", des="Ds. Sigla", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsSigla;

	public Integer getCdEstado() { return cdEstado; } 
	public void setCdEstado(Integer cdEstado) { 
		this.cdEstado = cdEstado; 
	}

	public String getDsEstado() { return dsEstado; } 
	public void setDsEstado(String dsEstado) { 
		this.dsEstado = dsEstado; 
	}

	public Integer getCdPais() { return cdPais; } 
	public void setCdPais(Integer cdPais) { 
		this.cdPais = cdPais; 
	}

	public Integer getCdRegiao() { return cdRegiao; } 
	public void setCdRegiao(Integer cdRegiao) { 
		this.cdRegiao = cdRegiao; 
	}

	public String getDsSigla() { return dsSigla; } 
	public void setDsSigla(String dsSigla) { 
		this.dsSigla = dsSigla; 
	}
	 
}
 

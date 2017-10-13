package br.com.virtual.model.logradouro;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="LOGRADOURO")
public class Logradouro extends _PersistDAO {
 
	@Column(cod="CD_CEP", des="Cod. Cep", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdCep;
	 
	@Column(cod="CD_MUNICIPIO", des="Cod. Municipio", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0, cls="Municipio")
	private Integer cdMunicipio;
	 
	@Column(cod="CD_BAIRRO", des="Cod. Bairro", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0, cls="Bairro")
	private Integer cdBairro;
	 
	@Column(cod="TP_LOGRADOURO", des="Tp. Logradouro", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=10, dec=0)
	private String tpLogradouro;
	 
	@Column(cod="DS_LOGRADOURO", des="Ds. Logradouro", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsLogradouro;
	 
	@Column(cod="DS_COMPL", des="Ds. Compl", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsCompl;

	public Integer getCdCep() { return cdCep; } 
	public void setCdCep(Integer cdCep) { 
		this.cdCep = cdCep; 
	}

	public Integer getCdMunicipio() { return cdMunicipio; } 
	public void setCdMunicipio(Integer cdMunicipio) { 
		this.cdMunicipio = cdMunicipio; 
	}

	public Integer getCdBairro() { return cdBairro; } 
	public void setCdBairro(Integer cdBairro) { 
		this.cdBairro = cdBairro; 
	}

	public String getTpLogradouro() { return tpLogradouro; } 
	public void setTpLogradouro(String tpLogradouro) { 
		this.tpLogradouro = tpLogradouro; 
	}

	public String getDsLogradouro() { return dsLogradouro; } 
	public void setDsLogradouro(String dsLogradouro) { 
		this.dsLogradouro = dsLogradouro; 
	}

	public String getDsCompl() { return dsCompl; } 
	public void setDsCompl(String dsCompl) { 
		this.dsCompl = dsCompl; 
	}
	 
}
 

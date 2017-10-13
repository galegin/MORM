package br.com.virtual.model.venda;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="VENDAENDER")
public class VendaEnder extends _PersistDAO {
 
	@Column(cod="CD_VENDA", des="Cod. Venda", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdVenda;
	 
	@Column(cod="CD_CEP", des="Cod. Cep", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdCep;
	 
	@Column(cod="DS_ENDERECO", des="Ds. Endereco", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsEndereco;
	 
	@Column(cod="NR_ENDERECO", des="Nr. Endereco", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=10, dec=0)
	private String nrEndereco;
	 
	@Column(cod="DS_BAIRRO", des="Ds. Bairro", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsBairro;
	 
	@Column(cod="DS_CIDADE", des="Ds. Cidade", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsCidade;
	 
	@Column(cod="DS_ESTADO", des="Ds. Estado", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsEstado;
	 
	@Column(cod="DS_COMPL", des="Ds. Compl", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsCompl;

	public Integer getCdVenda() { return cdVenda; } 
	public void setCdVenda(Integer cdVenda) { 
		this.cdVenda = cdVenda; 
	}

	public Integer getCdCep() { return cdCep; } 
	public void setCdCep(Integer cdCep) { 
		this.cdCep = cdCep; 
	}

	public String getDsEndereco() { return dsEndereco; } 
	public void setDsEndereco(String dsEndereco) { 
		this.dsEndereco = dsEndereco; 
	}

	public String getNrEndereco() { return nrEndereco; } 
	public void setNrEndereco(String nrEndereco) { 
		this.nrEndereco = nrEndereco; 
	}

	public String getDsBairro() { return dsBairro; } 
	public void setDsBairro(String dsBairro) { 
		this.dsBairro = dsBairro; 
	}

	public String getDsCidade() { return dsCidade; } 
	public void setDsCidade(String dsCidade) { 
		this.dsCidade = dsCidade; 
	}

	public String getDsEstado() { return dsEstado; } 
	public void setDsEstado(String dsEstado) { 
		this.dsEstado = dsEstado; 
	}

	public String getDsCompl() { return dsCompl; } 
	public void setDsCompl(String dsCompl) { 
		this.dsCompl = dsCompl; 
	}
	 
}
 

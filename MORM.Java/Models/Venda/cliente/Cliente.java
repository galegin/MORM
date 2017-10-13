package br.com.virtual.model.cliente;

import br.com.virtual.jpa.Column;
import br.com.virtual.jpa.Entity;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;
import br.com.virtual.enumeration.TipoIncr;

import java.util.Date;

@Entity(cod="CLIENTE")
public class Cliente extends _PersistDAO {
 
	@Column(cod="CD_CLIENTE", des="Cod. Cliente", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0, inc=TipoIncr.SEQ)	
	private Integer cdCliente;
 
	@Column(cod="NM_CLIENTE", des="Nome Cliente", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String nmCliente;
	 
	@Column(cod="NR_CPFCNPJ", des="Nr. Cpfcnpj", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=20, dec=0)
	private String nrCpfCnpj;
	 
	@Column(cod="NR_RGIE", des="Nr. Rgie", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=20, dec=0)
	private String nrRgIe;
	 
	@Column(cod="NM_APELIDO", des="Nome Apelido", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String nmApelido;
	 
	@Column(cod="DT_NASCTO", des="Dt. Nascto", tpf=TipoField.REQ, tpd=TipoDado.DATAHORA, tam=10, dec=0)
	private Date dtNascto;
	 
	@Column(cod="TP_SEXO", des="Tp. Sexo", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=10, dec=0, lst="F=Feminino;M=Masculino", cls="Cliente")
	private String tpSexo;
	 
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
	 
	@Column(cod="DS_PAIS", des="Ds. Pais", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsPais;
	 
	@Column(cod="DS_COMPL", des="Ds. Compl", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsCompl;
	 
	@Column(cod="DS_FONEPRI", des="Ds. Fonepri", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=20, dec=0)
	private String dsFonePri;
	 
	@Column(cod="DS_FONESEC", des="Ds. Fonesec", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=20, dec=0)
	private String dsFoneSec;
	 
	@Column(cod="DS_FONECEL", des="Ds. Fonecel", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=20, dec=0)
	private String dsFoneCel;
	 
	@Column(cod="DS_EMAILPRI", des="Ds. Emailpri", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsEmailPri;
	 
	@Column(cod="DS_EMAILSEC", des="Ds. Emailsec", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsEmailSec;
	 
	@Column(cod="NM_LOGIN", des="Nome Login", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String nmLogin;
	 
	@Column(cod="CD_SENHA", des="Cod. Senha", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0, pwd=true, def="123@mudar")
	private String cdSenha;

	public Integer getCdCliente() { return cdCliente; } 
	public void setCdCliente(Integer cdCliente) { 
		this.cdCliente = cdCliente; 
	}

	public String getNmCliente() { return nmCliente; } 
	public void setNmCliente(String nmCliente) { 
		this.nmCliente = nmCliente; 
	}

	public String getNrCpfCnpj() { return nrCpfCnpj; } 
	public void setNrCpfCnpj(String nrCpfCnpj) { 
		this.nrCpfCnpj = nrCpfCnpj; 
	}

	public String getNrRgIe() { return nrRgIe; } 
	public void setNrRgIe(String nrRgIe) { 
		this.nrRgIe = nrRgIe; 
	}

	public String getNmApelido() { return nmApelido; } 
	public void setNmApelido(String nmApelido) { 
		this.nmApelido = nmApelido; 
	}

	public Date getDtNascto() { return dtNascto; } 
	public void setDtNascto(Date dtNascto) { 
		this.dtNascto = dtNascto; 
	}

	public String getTpSexo() { return tpSexo; } 
	public void setTpSexo(String tpSexo) { 
		this.tpSexo = tpSexo; 
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

	public String getDsPais() { return dsPais; } 
	public void setDsPais(String dsPais) { 
		this.dsPais = dsPais; 
	}

	public String getDsCompl() { return dsCompl; } 
	public void setDsCompl(String dsCompl) { 
		this.dsCompl = dsCompl; 
	}

	public String getDsFonePri() { return dsFonePri; } 
	public void setDsFonePri(String dsFonePri) { 
		this.dsFonePri = dsFonePri; 
	}

	public String getDsFoneSec() { return dsFoneSec; } 
	public void setDsFoneSec(String dsFoneSec) { 
		this.dsFoneSec = dsFoneSec; 
	}

	public String getDsFoneCel() { return dsFoneCel; } 
	public void setDsFoneCel(String dsFoneCel) { 
		this.dsFoneCel = dsFoneCel; 
	}

	public String getDsEmailPri() { return dsEmailPri; } 
	public void setDsEmailPri(String dsEmailPri) { 
		this.dsEmailPri = dsEmailPri; 
	}

	public String getDsEmailSec() { return dsEmailSec; } 
	public void setDsEmailSec(String dsEmailSec) { 
		this.dsEmailSec = dsEmailSec; 
	}

	public String getNmLogin() { return nmLogin; } 
	public void setNmLogin(String nmLogin) { 
		this.nmLogin = nmLogin; 
	}

	public String getCdSenha() { return cdSenha; } 
	public void setCdSenha(String cdSenha) { 
		this.cdSenha = cdSenha; 
	}
	 
}
 

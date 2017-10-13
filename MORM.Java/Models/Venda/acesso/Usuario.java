package br.com.virtual.model.acesso;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.classe._Variant;
import br.com.virtual.enumeration.TipoCombo;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;
import br.com.virtual.enumeration.TipoIncr;

import java.util.Date;

@Entity(cod="USUARIO")
public class Usuario extends _PersistDAO {
	
	@Column(cod="CD_USUARIO", des="Cod. Usuario", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0, inc=TipoIncr.MAX, tpc=TipoCombo.COD)
	private String cdUsuario;
	
	@Column(cod="NM_USUARIO", des="Nome Usuario", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0, tpc=TipoCombo.DES)
	private String nmUsuario;
	
	@Column(cod="NM_LOGIN", des="Nome Login", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String nmLogin;
	
	@Column(cod="CD_SENHA", des="Cod. Senha", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=40, dec=0, pwd=true, def="123@mudar")
	private String cdSenha;
	
	@Column(cod="TP_PRIVILEGIO", des="Tp. Privilegio", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=1, dec=0, lst="S=Suporte;A=Administrador;O=Operador;C=Consulta", def="C")
	private String tpPrivilegio;
	
	@Column(cod="TP_BLOQUEIO", des="Tp. Bloqueio", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=2, dec=0, lst="0=Liberado;1=Bloqueado", def="0")
	private Integer tpBloqueio;
	
	@Column(cod="DT_BLOQUEIO", des="Dt. Bloqueio", tpf=TipoField.NUL, tpd=TipoDado.DATAHORA, tam=10, dec=0)
	private Date dtBloqueio;	

	public String getCdUsuario() { return cdUsuario; } 
	public void setCdUsuario(String cdUsuario) { 
		this.cdUsuario = cdUsuario; 
	}

	public String getNmUsuario() { return nmUsuario; } 
	public void setNmUsuario(String nmUsuario) { 
		this.nmUsuario = nmUsuario; 
	}

	public String getNmLogin() { return nmLogin; } 
	public void setNmLogin(String nmLogin) { 
		this.nmLogin = nmLogin; 
	}

	public String getCdSenha() { return cdSenha; } 
	public void setCdSenha(String cdSenha) { 
		this.cdSenha = cdSenha; 
	}

	public String getTpPrivilegio() { return tpPrivilegio; } 
	public void setTpPrivilegio(String tpPrivilegio) { 
		this.tpPrivilegio = tpPrivilegio; 
	}

	public Integer getTpBloqueio() { return tpBloqueio; } 
	public void setTpBloqueio(Integer tpBloqueio) { 
		this.tpBloqueio = tpBloqueio; 
	}

	public Date getDtBloqueio() { return dtBloqueio; } 
	public void setDtBloqueio(Date dtBloqueio) { 
		this.dtBloqueio = dtBloqueio; 
	}
	
	public static void main(String[] args) {
		
		_Variant par = new _Variant();
		Usuario user = new Usuario();
		
		par.clear();
		par.putitem("nmLogin", "teste");
		_Variant res = user.consultar(par);
		if (res == null || res.itemS("cdUsuario").equals("")) {
			user.setNmUsuario("teste");
			user.setNmLogin("teste");
			user.salvar(null);
		}
		else {	
			System.out.println("res: " + res.getString());
		}
		
	}

}

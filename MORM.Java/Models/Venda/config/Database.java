package br.com.virtual.model.config;

import br.com.virtual.jpa.File;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistentXAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@File(cod="database.xml")
public class Database extends _PersistentXAO {

	@Column(cod="CD_AMBIENTE", des="Cd. Ambiente", tpf=TipoField.KEY, tpd=TipoDado.ALFA, tam=20, dec=0)
	private String cdAmbiente;

	@Column(cod="TP_DATABASE", des="Tp. Database", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=20, dec=0)
	private String tpDatabase;

	@Column(cod="CD_DATABASE", des="Cod. Database", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String cdDatabase;

	@Column(cod="CD_USERNAME", des="Cod. Username", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String cdUsername;
	
	@Column(cod="CD_PASSWORD", des="Cod. Password", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String cdPassword;
	
	@Column(cod="CD_HOSTNAME", des="Cod. Hostname", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String cdHostname;
	
	@Column(cod="CD_HOSTPORT", des="Cod. Hostport", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=10, dec=0)
	private String cdHostport;

	public String getCdAmbiente() { return cdAmbiente; }
	public void setCdAmbiente(String cdAmbiente) {
		this.cdAmbiente = cdAmbiente;
	}
	
	public String getTpDatabase() { return tpDatabase; } 
	public void setTpDatabase(String tpDatabase) { 
		this.tpDatabase = tpDatabase; 
	}

	public String getCdDatabase() { return cdDatabase; } 
	public void setCdDatabase(String cdDatabase) { 
		this.cdDatabase = cdDatabase; 
	}

	public String getCdUsername() { return cdUsername; } 
	public void setCdUsername(String cdUsername) { 
		this.cdUsername = cdUsername; 
	}

	public String getCdPassword() { return cdPassword; } 
	public void setCdPassword(String cdPassword) { 
		this.cdPassword = cdPassword; 
	}

	public String getCdHostname() { return cdHostname; } 
	public void setCdHostname(String cdHostname) { 
		this.cdHostname = cdHostname; 
	}

	public String getCdHostport() { return cdHostport; } 
	public void setCdHostport(String cdHostport) { 
		this.cdHostport = cdHostport; 
	}

}

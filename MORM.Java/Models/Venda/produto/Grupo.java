package br.com.virtual.model.produto;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="GRUPO")
public class Grupo extends _PersistDAO {
 
	@Column(cod="CD_GRUPO", des="Cod. Grupo", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdGrupo;
	 
	@Column(cod="DS_GRUPO", des="Ds. Grupo", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsGrupo;
	 
	@Column(cod="CD_GRUPOPAI", des="Cod. Grupopai", tpf=TipoField.NUL, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdGrupoPai;

	public Integer getCdGrupo() { return cdGrupo; } 
	public void setCdGrupo(Integer cdGrupo) { 
		this.cdGrupo = cdGrupo; 
	}

	public String getDsGrupo() { return dsGrupo; } 
	public void setDsGrupo(String dsGrupo) { 
		this.dsGrupo = dsGrupo; 
	}

	public Integer getCdGrupoPai() { return cdGrupoPai; } 
	public void setCdGrupoPai(Integer cdGrupoPai) { 
		this.cdGrupoPai = cdGrupoPai; 
	}
	 
}
 

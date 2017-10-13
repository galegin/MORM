package br.com.virtual.model.store;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.web.AppPath;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.classe.store._Clob;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;
import br.com.virtual.enumeration.TipoIncr;

@Entity(cod="CONTEUDO")
public class Conteudo extends _PersistDAO 
{ 
	@Column(cod="NR_CONTEUDO", des="Nr. Conteudo", tpf=TipoField.KEY, tpd=TipoDado.ALFA, tam=9, dec=0, inc=TipoIncr.MAX)
	private Integer nrConteudo;
	 
	@Column(cod="CD_CONTEUDO", des="Cod. Conteudo", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=100, dec=0)
	private String cdConteudo;
	 
	@Column(cod="DS_CONTEUDO", des="Ds. Conteudo", tpf=TipoField.REQ, tpd=TipoDado.TEXTO, tam=60, dec=0, def="N")
	private _Clob dsConteudo;

	public Integer getNrConteudo() { return nrConteudo; } 
	public void setNrConteudo(Integer nrConteudo) { 
		this.nrConteudo = nrConteudo;
	}

	public String getCdConteudo() { return cdConteudo; } 
	public void setCdConteudo(String cdConteudo) { 
		this.cdConteudo = cdConteudo;
	}

	public _Clob getDsConteudo() { return dsConteudo; } 
	public void setDsConteudo(_Clob dsConteudo) { 
		this.dsConteudo = dsConteudo; 
	}

	public static void main(String[] args) 
	{		
		Conteudo conteudo = null;
		String arq = null;
		
		_Clob clob = new _Clob();
		
		String lstext[] = {"txt"};
		
		int i = 1;
		for (String ext : lstext) 
		{		
			//-- gravar
			arq = AppPath.getInstance().getAppPath() + "teste." + ext;
			clob.carregarArq(arq);
			conteudo = new Conteudo();
			conteudo.setNrConteudo(i);
			conteudo.setCdConteudo(arq);
			conteudo.setDsConteudo(clob);
			conteudo.salvar(null);
			
			//-- consultar
			conteudo = new Conteudo();
			conteudo.setNrConteudo(i);
			conteudo.consultar(null);
			clob = conteudo.getDsConteudo();
			arq = AppPath.getInstance().getAppPath() + "teste1.cnt." + ext;
			clob.gravarArq(arq);
			
			i++;
		}
	}
}
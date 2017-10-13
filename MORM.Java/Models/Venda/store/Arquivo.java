package br.com.virtual.model.store;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.web.AppPath;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.classe.store._Blob;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;
import br.com.virtual.enumeration.TipoIncr;

@Entity(cod="ARQUIVO")
public class Arquivo extends _PersistDAO 
{ 
	@Column(cod="NR_ARQUIVO", des="Nr. Arquivo", tpf=TipoField.KEY, tpd=TipoDado.ALFA, tam=9, dec=0, inc=TipoIncr.MAX)
	private Integer nrArquivo;
	 
	@Column(cod="CD_ARQUIVO", des="Cod. Arquivo", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=100, dec=0)
	private String cdArquivo;
	 
	@Column(cod="DS_ARQUIVO", des="Ds. Arquivo", tpf=TipoField.REQ, tpd=TipoDado.BINARY, tam=60, dec=0, def="N")
	private _Blob dsArquivo;

	public Integer getNrArquivo() { return nrArquivo; } 
	public void setNrArquivo(Integer nrArquivo) { 
		this.nrArquivo = nrArquivo; 
	}

	public String getCdArquivo() { return cdArquivo; } 
	public void setCdArquivo(String cdArquivo) { 
		this.cdArquivo = cdArquivo; 
	}

	public _Blob getDsArquivo() { return dsArquivo; } 
	public void setDsArquivo(_Blob dsArquivo) { 
		this.dsArquivo = dsArquivo; 
	}

	public static void main(String[] args) 
	{		
		Arquivo arquivo = null;
		String arq = null;
		
		_Blob blob = new _Blob();
		
		String lstext[] = {"pdf", "txt"};
		
		int i = 1;
		for (String ext : lstext) 
		{		
			//-- gravar
			arq = AppPath.getInstance().getAppPath() + "teste." + ext;
			blob.carregarArq(arq);
			arquivo = new Arquivo();
			arquivo.setNrArquivo(i);
			arquivo.setCdArquivo(arq);
			arquivo.setDsArquivo(blob);
			arquivo.salvar(null);
			
			//-- consultar
			arquivo = new Arquivo();
			arquivo.setNrArquivo(i);			
			arquivo.consultar(null);
			blob = arquivo.getDsArquivo();			
			arq = AppPath.getInstance().getAppPath() + "teste1.arq." + ext;
			blob.gravarArq(arq);
			
			i++;
		}
	}
}
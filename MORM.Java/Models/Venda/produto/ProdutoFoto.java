package br.com.virtual.model.produto;

import java.sql.Blob;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="PRODUTOFOTO")
public class ProdutoFoto extends _PersistDAO {
 
	@Column(cod="CD_PRODUTO", des="Cod. Produto", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdProduto;
	 
	@Column(cod="CD_FOTO", des="Cod. Foto", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdFoto;
	 
	@Column(cod="CD_ARQUIVO", des="Cod. Arquivo", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=100, dec=0)
	private String cdArquivo;
	 
	@Column(cod="DS_ARQUIVO", des="Ds. Arquivo", tpf=TipoField.REQ, tpd=TipoDado.IMAGE, tam=60, dec=0)
	private Blob dsArquivo;

	public Integer getCdProduto() { return cdProduto; } 
	public void setCdProduto(Integer cdProduto) { 
		this.cdProduto = cdProduto; 
	}

	public Integer getCdFoto() { return cdFoto; } 
	public void setCdFoto(Integer cdFoto) { 
		this.cdFoto = cdFoto; 
	}

	public String getCdArquivo() { return cdArquivo; } 
	public void setCdArquivo(String cdArquivo) { 
		this.cdArquivo = cdArquivo; 
	}

	public Blob getDsArquivo() { return dsArquivo; } 
	public void setDsArquivo(Blob dsArquivo) { 
		this.dsArquivo = dsArquivo; 
	}
	 
}
 

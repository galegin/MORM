package br.com.virtual.model.produto;

import java.sql.Clob;

import br.com.virtual.jpa.Entity;
import br.com.virtual.jpa.Column;
import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;

@Entity(cod="PRODUTOFICHA")
public class ProdutoFicha extends _PersistDAO {
 
	@Column(cod="CD_PRODUTO", des="Cod. Produto", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdProduto;
	 
	@Column(cod="CD_CAMPO", des="Cod. Campo", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=10, dec=0)
	private Integer cdCampo;
	 
	@Column(cod="DS_CAMPO", des="Ds. Campo", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsCampo;
	 
	@Column(cod="DS_CONTEUDO", des="Ds. Conteudo", tpf=TipoField.REQ, tpd=TipoDado.TEXTO, tam=60, dec=0)
	private Clob dsConteudo;

	public Integer getCdProduto() { return cdProduto; } 
	public void setCdProduto(Integer cdProduto) { 
		this.cdProduto = cdProduto; 
	}

	public Integer getCdCampo() { return cdCampo; } 
	public void setCdCampo(Integer cdCampo) { 
		this.cdCampo = cdCampo; 
	}

	public String getDsCampo() { return dsCampo; } 
	public void setDsCampo(String dsCampo) { 
		this.dsCampo = dsCampo; 
	}

	public Clob getDsConteudo() { return dsConteudo; } 
	public void setDsConteudo(Clob dsConteudo) { 
		this.dsConteudo = dsConteudo; 
	}
	 
}
 

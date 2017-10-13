package br.com.virtual.model.store;

import java.util.Date;

import br.com.virtual.classe._PersistDAO;
import br.com.virtual.enumeration.TipoDado;
import br.com.virtual.enumeration.TipoField;
import br.com.virtual.enumeration.TipoIncr;
import br.com.virtual.jpa.Column;
import br.com.virtual.jpa.Entity;

@Entity(cod="TESTE")
public class Teste extends _PersistDAO 
{	
	@Column(cod="CD_TESTE", des="Cd. Teste", tpf=TipoField.KEY, tpd=TipoDado.NUMERO, tam=9, dec=0, inc=TipoIncr.MAX)
	private Integer cdTeste;
	
	@Column(cod="DS_TESTE", des="Ds. Teste", tpf=TipoField.REQ, tpd=TipoDado.ALFA, tam=60, dec=0)
	private String dsTeste;
	
	@Column(cod="DT_TESTE", des="Dt. Teste", tpf=TipoField.REQ, tpd=TipoDado.DATAHORA, tam=20, dec=0)
	private Date dtTeste;
	
	@Column(cod="IN_TESTE", des="In. Teste", tpf=TipoField.REQ, tpd=TipoDado.BOOLEANO, tam=1, dec=0)
	private Boolean inTeste;
	
	@Column(cod="VL_TESTE", des="Vl. Teste", tpf=TipoField.REQ, tpd=TipoDado.NUMERO, tam=15, dec=2)
	private Float vlTeste;

	public Integer getCdTeste() { return cdTeste; }
	public void setCdTeste(Integer cdTeste) {
		this.cdTeste = cdTeste;
	}

	public String getDsTeste() { return dsTeste; }
	public void setDsTeste(String dsTeste) {
		this.dsTeste = dsTeste;
	}

	public Date getDtTeste() { return dtTeste; }
	public void setDtTeste(Date dtTeste) {
		this.dtTeste = dtTeste;
	}

	public Boolean getInTeste() { return inTeste; }
	public void setInTeste(Boolean inTeste) {
		this.inTeste = inTeste;
	}

	public Float getVlTeste() { return vlTeste;	}
	public void setVlTeste(Float vlTeste) {
		this.vlTeste = vlTeste;
	}
	
	public static void main(String[] args) 
	{		
		Teste teste = new Teste();
		teste.setCdTeste(1);
		teste.setDsTeste("TESTE");
		teste.setDtTeste(new Date());
		teste.setInTeste(true);
		teste.setVlTeste(10F);
		teste.salvar(null);
		
		teste = new Teste();
		teste.setCdTeste(1);
		teste.consultar(null);
		System.out.println("values: " + teste.getValues());
	}
}
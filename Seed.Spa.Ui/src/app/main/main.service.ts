import { Injectable } from '@angular/core';
import { Observable, Observer, Subject } from 'rxjs';
import { FormGroup, FormControl } from '@angular/forms';

//import { ApiService } from 'app/common/services/api.service';
import { ApiService } from '../common/services/api.service';
import { ServiceBase } from '../common/services/service.base';
import { ViewModel } from '../common/model/viewmodel';
import { GlobalService } from '../global.service';
import { GlobalServiceCulture, Translated, TranslatedField } from '../global.service.culture';

@Injectable()
export class MainService extends ServiceBase {


  constructor(private globalServiceCulture: GlobalServiceCulture, private api: ApiService<any>) {
    super();
  }

  updateCulture(vm: any, culture: string = null) {
    this.getInfosTranslated(this.globalServiceCulture.defineCulture(culture)).then((result: any) => {
      vm.generalInfo = result;
    });
  }

  resetCulture() {
    this.globalServiceCulture.reset();
  }

  getInfosTranslated(culture: string) {
    return this.globalServiceCulture.getInfosTranslatedStrategy('Geral', culture, this.getInfos(), []);
  }

  getInfos() {
    return this.getInfosFields();
  }

  getInfosFields() {
    return {
      buscar: { label: 'Buscar' },
      voltar: { label: 'Voltar' },
      sair: { label: 'Sair' },
      filtro: { label: 'Filtros' },
      novoItem: { label: 'Novo item' },
      titulo: { label: 'Titulo' },
      acao: { label: 'AÃ§Ã£o' },
      totalRegistro: { label: 'Total de registros' },
      proximo: { label: 'PrÃ³ximo' },
      anterior: { label: 'Anterior' },
      filtrar: { label: 'Filtrar' },
      salvar: { label: 'Salvar' },
      cancelar: { label: 'Cancelar' },
      sim: { label: 'Ok' },
      imprimir: { label: 'Imprimir' },
      procurar: { label: 'Procurar' },
      excluir: { label: 'Excluir' },
      limpar: { label: 'Limpar' },
    }
  }
}

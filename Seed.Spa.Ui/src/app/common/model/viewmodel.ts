import { FormGroup, FormControl } from '@angular/forms';

export class ViewModel<T> {


  constructor(init: any = null) {

    this.mostrarFiltros = init.mostrarFiltros;
    this.manterTelaAberta = init.manterTelaAberta;
    this.navigationModal = init.navigationModal;
    this.actionTitle = init.actionTitle;
    this.actionDescription = init.actionDescription;
    this.downloadUri = init.downloadUri;
    this.filterResult = init.filterResult;
    this.modelFilter = init.modelFilter;
    this.summary = init.summary;
    this.model = init.model;
    this.details = init.details;
    this.generalInfo = init.generalInfo;
    this.infos = init.infos;
    this.grid = init.grid;
    this.form = init.form;
    this.masks = init.masks;
    this.reletedViewModel = init.reletedViewModel;
    this.gridCheckModel = init.gridCheckModel;
    this.isParent = init.isParent;
    this.ParentIdField = init.ParentIdField;
  }

  mostrarFiltros: boolean;
  manterTelaAberta: boolean;
  navigationModal: boolean;
  actionTitle: string;
  actionDescription: string;
  downloadUri: string;
  filterResult: T[];
  modelFilter: any;
  summary: any;
  model: T;
  details: T;
  generalInfo: any;
  infos: any;
  grid: any;
  form: FormGroup;
  masks: any;
  reletedViewModel: any;
  gridCheckModel: any;
  isParent: Boolean;
  ParentIdField: string;
}

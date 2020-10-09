import { Sexe } from 'src/app/helper/enumeration/sexe.enum';

export class Professeur {
  id: number;
  nom: string;
  postnom: string;
  prenom: string;
  sexe: Sexe;
  photo: string;
  email: string;
  titreFormation: string;
}

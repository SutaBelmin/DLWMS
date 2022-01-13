import { Fakultet } from "./Fakultet";
import { KorisnickiNalog } from "./KorisnickiNalog";

export interface Student {
  id: number;
  ime: string;
  prezime: string;
  broj_indeksa:string;
  datum_rodjenja: string;
  slika_studenta: string;

  fakultetID: number;
  fakultet: Fakultet;

  korisnickiNalogID: number;
  korisnickiNalog: KorisnickiNalog;

}

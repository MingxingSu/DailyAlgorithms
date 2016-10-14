using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _318_MaximumProductOfWordLengths
{
    public class PerformanceTest
    {
        public void PerformanceTestMethod1()
        {  
            string[] words = new string[]
            {
                "bkapomjbpccemkpegpgpbpaei","lapljaeffhd","nbpnkc","hlaekonhhljd","dlphhcfaonaa","gpkpfendpcjfgnkeepbobokodhdgdajeebagejhnlgfk","ffiaanimfgdlfplegcibleabiaep","kenondpllfifeoajebemkjnmhgfgaag","ihmfmdibne","daljaone","ehhhojabijneclhlknpdbfbbahdnfklphpmghadjbmeo","kflolejcecljakjnhlgpi","kefhdbchkmdklhakf","kkfkjoephgapddnec","mdpeahlfljafigjghmggpaaiphaaninoaecpfhkn","lcfojgmppoemaamclmbene","llnnglgjdfgajboafloofdeeagnaghgjmepkfoejgk","odncgbijkandbnijfaamonaafplmadmhhk","delnjdlbfbbaoijjghpbjdpphgodojai","kjncppm","ljhgbnobfgffcegffcnckd","ejgdhh","ejignpipmabehdamibidpfnljgeejhbcdcd","mfighoiphpfodj","mebgbepbpkfminidnealmmaeeloeeicmgebojamkegkmnhmkie","fagmgjppibdelmpbbkgipnpgpppmahigcfimgoeolmdeofe","oojfmacjklenikdcckfhibnochjmehpfnoipibdcbj","fdmdmlgcnhknipckoik","oacgcakpijkdcknmfkachbijlkidlhmkp","egpmcllhjlmgickcbjgafkcpdkifkhlgob","gehndlohcl","efchkpalbdkjneemoaa","nddkg","nielbophegclnoo","dhfgmjpfk","bnpfgljifdopicenhgcekhond","pcodleopclefhickcbccfjenkjgijijmdpfmogj","iglnbn","jkmjodloihpnmmij","jpapdbcpiagdgfkmkcpoioepagikbjaijpkemobdpd","gaegicpppijpjapnjlmonopdndhkiedoojcmlffdna","nfkf","gmmamcbloeapelpnjdoecl","knabmpekkaomihlhamdgpbnf","emjgibpcgjhgblkalkgopbbliok","hiibnlkjllhdpfgakoohlheomjblpfhfhkpcggoael","lplbmoadkpjhbmblgeonp","imfckjoebkf","blkbgfkm","kfgaokopgdmgkipmjbpopejelnnfamebpkl","cjgijbkdcpomhgpaflgohcdecf","gohfbnadmcofgliijofhmmfpdlmeepaeioohokif","pdpekjnkjcmmjpbbpdhfm","cffdhbjhjodobfde","lokmac","haofjpnahoapbhdipeelkajpmpohclom","edofddfmmnnoedcjnlpdlpohnmknpmcn","jiiggmggibohignp","aijdngbfooanphgfjebfhhdbf","jifnmhmkhcbmnehdfdclbpiamhlphbdckjkhaji","abapnjamanhmlgofojlfajdoggmealkfoanifdjpmkmnohkiepg","ocmbboiaifcgncjikikpdgbamjpnhkjpicdbphkabdjhnok","cmbhecenkkjcogfmlhklgijjcnbkojopn","mhhhe","imkgdbiingihlejbdakbmdfoh","bhpgadeaidjpoo","nhogbgnmjkmbcbnblijfmbhpnmpopfllnblap","mcnikjpc","lmgcoaolageiodofkepmomhkijhgmogoiekcmdhjjljj","idcipheddplhaagjkl","imkdmmdeaiboginl","acinhjhnemeg","ijfkbjmgmhkfhodoabmihekhhneaiggbaknaeda","ahkjioliokfgjpjpapoafnojckkhkfahindimfkejeoiecfdbb","iccfijoeapaohiniedfmnampf","ohejeeicpofmhkcdlnfkjjnhpakhpjldiga","locagccpjcikkebighemcadbnbkafladdoljiacddigbjpmh","edcjimnfkbobgmhgmlhcnpkkodahpa","bagogfmjgkbfjgojibnbacgghkcg","iidamgpkloldlbgpcnfgkpnamh","dnndggdihoiilpfhfknheaeeedmijfmhonl","hajenlpnca","fkgefohefnigml","alkacmieadhplmpegpcalghmhjbagenmbghlnanaljfkgcpmcp","lgfim","mgmlpmkgejkmlognmdcejoocdnfkb","ickdnlfmppemplpahjghghmbp","jemghaahdfaolljbkhcjfjepdiaemg","jinfeappjdgimnbfnffpjlilkidelilkdgcimdgoo","fofagimdeemfbjbflefipac","ecjghpilaanjenmdkfk","dlicbelclllalnhncha","fncpcbdafldiokifhhmaobhlfhebpngipacbh","pbdhoagfmbhgljjfndadhgogak","kcddpkcjgldblbfaejbkaegfaflnjjaclnkhpghmfeelbhnikgh","fnappejgmcgkmjmbeogpbofm","bfopcki","nndfmjjmma","bimjjgnogljdakb","ldnnbejaibmpdbonffdhclgbmpj","iiedinlfkhafnjjinooihbnhh","clfclnlgkjfidfkpppchklfbo","bfjdhjocpfaaniiaacclfaphpelbndjgkceffanbcbmbokhcoik","pjgblgehmpggih","iempdiijoddichnkfhfpambcaphgdkmdgbokn","oldnnjamlflgaliafcmijhmmdaoocekfhaogik","ckjikb","jjpifalekpghhieihkkmpief","njefkicopkfdnljhopceldgibodpfkhafkkchkmhejili","fgmikknehjkkfhjfegddgaijpcedl","djdmikjkkemandllpdpookdmijhapjhbfegkopldlldgcdck","paaomjb","lakegclefoaiafban","bkedpefghlcennmfjeaglgjcognhcil","mdkgfko","jkkdacjnmgddgkgp","boagbfbfkliaihphockilndcfihcag","ochhhaienpo","gh","plmdbmeglapkbnfcebafo","dapgbhaopjeaeieeggcbhjckaflaiojjmjplpokbbkfmgjbg","kaiffmaplgaepjihidapemncnho","fkdjnmanmgnhjamcfmceplmpj","onnhnpllibpejgldlkfodmkpjpkcdfpifjpndgapdilcdfh","igdgijnelemmmjjcil","idoafgmaiid","ggommjdijjolgimggpgld","nlbomhnbddmaon","ijkfcbbehfdpmhhkm","kbejecojikkmlmdneffhcobdadodlgdmcmpgfgkddg","jhndiffnkanfaiainapaclklnikllcf","gaokgeobjna","glbdpbcbnkkmnbhajenkofkldgehaagneikmmnhp","blhpindafoglncfhibcbhbjnjmdh","jfeiieeldbmjim","go","fbhmcjfgfnfdbafmicgdl","lidljaflpnpjpcpggpgdangpcjhbbclcniaeanbmpddhf","pmpgfjdajehphpobkiebocfkonakpilea","lkmfhjbdkhebopigccljijmkielkmedmnidhagocfjdjf","fkflogajdfjpmmlknbpfnd","knaooaaoamlbbcdjfmcpbfifmkjdclcbeaoopinh","hebihekbgpfpafjgndhjboeplba","kakplajahjclcmmnlhegbfginjnhcpnjeak","kgpepfbc","ckaibjhhenpeeeeknmcoodccohlapmllpeppemeoindcgbhb"
            };

            Solution s = new Solution();
            var now = DateTime.Now;
            var max = s.MaxProduct(words);
            var timeUsed = DateTime.Now.Subtract(now).TotalSeconds;

            Console.WriteLine("Words:{0} ;" + Environment.NewLine + " MaxProduct:{1}, Execution Time:{2}",
                String.Join(",", words),
                max,
                timeUsed);

        }

    }
}

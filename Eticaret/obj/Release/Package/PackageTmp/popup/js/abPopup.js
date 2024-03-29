    /**
     * * -------------------------------------------------------------------------------------------------------
     * Bu jQuery eklentisi Aycan BULBUL(http://www.aycan.net/cookieli-popup-eklentisi/) tarafından yapilmistir.
     * Eklenti Adi  : Cookie'li popup uygulaması  
     * Yazar        : Aycan BULBUL, ab@aycan.net
     * Tarih        : Tarih 27 Mayıs 2011
     * * -------------------------------------------------------------------------------------------------------
     * Kullanim klavuzu
     * jQuery('#abPopup').abPopup(); // basit kullanim
     *
     * jQuery('#abPopup').abPopup
     * ({
     *      ### Acilis ###
     *      'acilis'         : otomatik veya tiklama
     *      'pozisyon'       : ortala,ortala veya ortal,top,50px
     *      'arkaplan'       : opsiyonel
     *      'arkaplanSaydam' : opsiyonel (arkaplanin saydamlik derecesi)
     *      ### Kapanis ###
     *      'htmlTag'        : opsiyonel (#buton, .buton vs.)
     *      'siyahCerceve'   : true veya false (Arka plana tiklayinca kapanma)
     *      'esc'            : true veya false (Esc tusuna basinca kapatma)
            'cookieGun'      : gun adedi girilebilir. orn : 1 , 8 , 10 vb.
     * });
     * * -------------------------------------------------------------------------------------------------------
     **/


    (function(jQuery){
         jQuery.fn.abPopup = function(veriAkisi)
         {

            var varsayilan =
            {
                /*acilis*/
                acilis         :'otomatik',
                pozisyon       :'ortala',
                arkaplan       :'#000',
                arkaplanSaydam :'0.3',
                /*kapanis*/
                htmlTag        :'#ab-kapat',
                siyahCerceve   : true,
                esc            : true,
                cookieGun      : 1
            };

            var ayarlar = jQuery.extend(varsayilan, veriAkisi);

            return this.each
            (
                function()
                {
                    var obje = jQuery(this);
                    jQuery(obje).css({
                       'position': 'absolute',
                       'z-index' : '9999'
                    });
                    /**
                     * Tanimlanmis acilis degerine gore islem yapiyoruz
                     * acilis = direk ise sayfa yuklendiginde popup aciliyor
                     **/
                    var deger2 = varsayilan.acilis.split(",");

                    switch (deger2[0]) {
                        case 'otomatik':
                            cookieKontrol(varsayilan.cookieGun);
                            break;

                        case 'tiklama':
                            /*sayfanin genisligini ve yuksekligini aliyoruz */
                          jQuery('#' + deger2[1]).click(function(){
                            cookieKontrol(varsayilan.cookieGun);
                              
                          });
                                break;
                        default:
                            alert('Yanlış bir veri girdiniz. Girilecek Degerler :  otomatik veya tiklama');
                            break;
                    }
                    /*cookie kontrol*/
                    function cookieKontrol(cookieGun)
                    {
                        if($.cookie('popup')== 0 || $.cookie('popup')== null )
                        {
                            /**
                            *Popup acildiktan sonra cookie degerine 2 atiyoruz ve acildi anlamina geliyor :)
                            **/
                            $.cookie('popup','1',{expires: cookieGun});
                            /**
                            * Popup actiriyoruz
                            **/
                            arkaPlan();
                        }
                        else
                        {
                            
                        }
                        
                    }

                    /*Arkaplan actiriyoruz*/
                    function arkaPlan()
                    {
                        window.ekran_genisligi  = jQuery('body').width();
                        window.ekran_yuksekligi = jQuery('body').height();
                        window.ekran_yuksekligi2 = jQuery(document).height();
                    /*sayfanin genisligini ve yuksekligini aliyoruz */
                        /*Eger sitenin yuksekligi ekranin yuksekliginden kucukse siteninin yuksekligini ekraninn yuksekligine esitliyoruz.*/
                        if(ekran_yuksekligi <= ekran_yuksekligi2 )
                        {
                            ekran_yuksekligi = ekran_yuksekligi2;
                        }
                        /*aldigimiz degerleri body taginin icine ekledigimiz div'e veriyoruz*/
                        jQuery('body').append('<div id="ab-popup-kararti" style="width:' + ekran_genisligi + 'px; height:' + ekran_yuksekligi + 'px; position:absolute; top:0; left:0; background:' + varsayilan.arkaplan + '; display:none; z-index:9998;"></div>');
                        /*arka zemini karartiyoruz*/
                        jQuery('#ab-popup-kararti').fadeTo('fast',varsayilan.arkaplanSaydam);
                        /*acilacak popup'un pozisyonunu belirliyoruz*/
                        jQuery(obje).find('#abPopup').delay(200).fadeIn('fast');
                        pozisyonBelirle();
                    }
                    /*Pozisyonu belirlileme*/
                    function pozisyonBelirle()
                    {
                        /* cift gonderilen deger varsa parcaliyoruz */
                        var deger1 = varsayilan.pozisyon.split(",");

                        /* 1. deger. ( ':' iki noktadan onceki deger) */
                        switch (deger1[1]){

                            case 'top':
                            /*yatay olarak ortaliyoruz*/
                            yatayOrtala();
                            /*Verilen top degerini atiyoruz*/
                            var obje_genislik = obje.width();
                            jQuery(obje).css({
                                'top' : deger1[2]
                            });
                            break;

                            case 'ortala':
                                /*yatay olarak ortaliyoruz*/
                                yatayOrtala();
                                /*dikey olarak ortaliyoruz*/
                                dikeyOrtala();
                            break;

                            default:
                                /*yatay olarak ortaliyoruz*/
                                yatayOrtala();
                                /*dikey olarak ortaliyoruz*/
                                dikeyOrtala();
                                break;
                        }
                        jQuery(obje).delay(250).fadeIn('slow');
                    }
                    /*Diket olarak ortalama fonksiyonu*/
                    function dikeyOrtala()
                    {
                        /*Eger acilacak popup'un yuksekligi ekran yusekliginden buyuk ise dikey olarak ortalama yapmiyoruz*/
                        if(jQuery(obje).height() > ekran_yuksekligi)
                        {
                            yatayOrtala();
                        }
                        else
                        {
                            jQuery(obje).css({
                                'top':'50%',
                                'margin-top':-jQuery(obje).find('#abPopup').height()/2
                            });
                        }
                    }
                    /*Yatay olarak ortalama fonksiyonu*/
                    function yatayOrtala()
                    {
                      jQuery(obje).css({
                            'left':'50%',
                            'margin-left':-jQuery(obje).find('#abPopup').width()/2
                        });
                    }

                    /*Kapatma*/
                    /*html tagina tiklaninca kapatma*/
                    jQuery(varsayilan.htmlTag).click(function(){
                        kapat();
                    });
                    /*siyah cerceveye tiklaninca kapatma*/
                    switch (varsayilan.siyahCerceve) {

                       case true:
                            jQuery('#ab-popup-kararti').live('click',function(){
                                kapat();
                            })
                            break;

                        default:
                            break;
                    }
                    /*esc'yw tiklaninca kapatma*/
                    switch (varsayilan.esc) {

                        case true:
                            jQuery(document).bind('keydown',function Kapat(e){
                                if (e.keyCode == 27) {
                                    kapat();
                                }
                            });
                            break;

                        default:
                            break;
                    }
                    /*kapatma fonksiyonu*/
                    function kapat()
                    {
                        jQuery(obje).find('#abPopup').delay(100).slideUp('fast');
                        jQuery('#ab-popup-kararti').delay(0).fadeOut('fast');
                            jQuery('#ab-popup-kararti').remove();

                    }

                }
            );
        };
    })(jQuery);


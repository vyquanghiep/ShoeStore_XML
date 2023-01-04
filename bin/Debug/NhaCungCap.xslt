<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>
	<xsl:param name="Data"></xsl:param>
    <xsl:template match="/NewDataSet">
		<html>
			<body>
				<br />
				<br />
				<center>
					<h1>DANH SÁCH NHÀ CUNG CẤP</h1>
				</center>

				<br />

				<br />
				<table border="1" width="100%">
					<tr>
						<th>STT</th>
						<th>Mã Nhà Cung Cấp</th>
						<th>Tên Nhà Cung Cấp</th>
						<th>Địa Chỉ</th>
						<th>Số Điện Thoại</th>
						<th>Email</th>
						<th>Mô Tả</th>
					</tr>

					<xsl:for-each select="NhanVien">
						<xsl:if test="MaNCC[.=$Data]">
							<tr>
								<td>
									<xsl:value-of select="position()"/>
								</td>
								<td>
									<xsl:value-of select="MaNCC"/>
								</td>
								<td>
									<xsl:value-of select="TenNCC"/>
								</td>
								<td>
									<xsl:value-of select="DiaChi"/>
								</td>
								<td>
									<xsl:value-of select="SDT"/>
								</td>
								<td>
									<xsl:value-of select="Email"/>
								</td>
								<td>
									<xsl:value-of select="MoTa"/>
								</td>
							</tr>
						</xsl:if>
					</xsl:for-each>
				</table>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
